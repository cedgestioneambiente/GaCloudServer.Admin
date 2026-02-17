using AutoWrapper;
using GaCloudServer.Admin.EntityFramework.Shared.DbContexts;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Identity;
using GaCloudServer.Admin.EntityFramework.Shared.Extensions;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Hub;
using GaCloudServer.Resources.Api.Configuration;
using GaCloudServer.Resources.Api.Configuration.Authorization;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Helpers;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Resources.Api.Resources;
using GaCloudServer.Shared.Dtos;
using GaCloudServer.Shared.Dtos.Identity;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Serilog;
using Skoruba.AuditLogging.EntityFramework.Entities;
using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Extensions;
using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Identity.Extensions;
using Skoruba.Duende.IdentityServer.Shared.Configuration.Helpers;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace GaCloudServer.Resources.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            HostingEnvironment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment HostingEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSignalR().AddHubOptions<NotificationHub>(options =>
            //{
            //    options.EnableDetailedErrors = true;
            //});

            services.AddSignalR();


            var resourcesApiConfiguration = Configuration.GetSection(nameof(ResourcesApiConfiguration)).Get<ResourcesApiConfiguration>();
            services.AddSingleton(resourcesApiConfiguration);

            //Disable Automatic Model State Validation
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            // Add DbContexts
            RegisterDbContexts(services);
            RegisterResourcesDbContexts(services);

            services.AddDataProtection<IdentityServerDataProtectionDbContext>(Configuration);

            services.AddScoped<ControllerExceptionFilterAttribute>();
            services.AddScoped<IApiErrorResources, ApiErrorResources>();

            services.AddLogging(options =>
            {
                options.AddSerilog(Log.Logger);
            });

            // Add authentication services
            RegisterAuthentication(services);

            // Add authorization services
            RegisterAuthorization(services);

            var profileTypes = new HashSet<Type>
            {
                typeof(IdentityMapperProfile<IdentityRoleDto, IdentityUserRolesDto, string, IdentityUserClaimsDto, IdentityUserClaimDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto, IdentityRoleClaimDto, IdentityRoleClaimsDto>)
            };

            services.AddAdminAspNetIdentityServices<AdminIdentityDbContext, IdentityServerPersistedGrantDbContext,
                IdentityUserDto, IdentityRoleDto, UserIdentity, UserIdentityRole, string, UserIdentityUserClaim, UserIdentityUserRole,
                UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken,
                IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto,
                IdentityUserClaimsDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
                IdentityRoleClaimsDto, IdentityUserClaimDto, IdentityRoleClaimDto>(profileTypes);

            services.AddAdminServices<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminLogDbContext>();
            services.AddResourcesRepository<ResourcesDbContext>();
            services.AddResourcesServices<ResourcesDbContext>();

            services.AddAdminApiCors(resourcesApiConfiguration);

            services.AddMvcServices<IdentityUserDto, IdentityRoleDto,
                UserIdentity, UserIdentityRole, string, UserIdentityUserClaim, UserIdentityUserRole,
                UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken,
                IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto,
                IdentityUserClaimsDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
                IdentityRoleClaimsDto, IdentityUserClaimDto, IdentityRoleClaimDto>();

            // API Versioning
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(), new HeaderApiVersionReader("x-api-version"));
            });

            // Versioned API explorer
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; // e.g. v1, v2
                options.SubstituteApiVersionInUrl = true;
            });

            // Swagger - create one doc per discovered API version
            services.AddSwaggerGen(options =>
            {
                // temporary provider to enumerate versions
                var provider = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();
                if (provider != null)
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(description.GroupName, new OpenApiInfo
                        {
                            Title = resourcesApiConfiguration.ApiName,
                            Version = description.ApiVersion.ToString()
                        });
                    }
                }

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{resourcesApiConfiguration.IdentityServerBaseUrl}/connect/authorize"),
                            TokenUrl = new Uri($"{resourcesApiConfiguration.IdentityServerBaseUrl}/connect/token"),
                            Scopes = new Dictionary<string, string> {
                                { resourcesApiConfiguration.OidcApiName, resourcesApiConfiguration.ApiName }
                            }
                        }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();

                // Ensure swagger only includes actions for the target version/group
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (apiDesc.GroupName == null) return false;
                    return apiDesc.GroupName == docName;
                });

            });

            services.AddAuditEventLogging<AdminAuditLogDbContext, AuditLog>(Configuration);

            services.AddIdSHealthChecks<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminIdentityDbContext, AdminLogDbContext, AdminAuditLogDbContext, IdentityServerDataProtectionDbContext,ResourcesDbContext>(Configuration, resourcesApiConfiguration);

            if (HostingEnvironment.IsDevelopment())
            {
                services
                .AddHealthChecksUI(setupSettings: setup => {
                    setup.AddHealthCheckEndpoint("ServerStatusEndpoint", "https://localhost:44312/health");
                })
                .AddInMemoryStorage();
            }
            else
            {
                //services
                //.AddHealthChecksUI(setupSettings: setup => {
                //    setup.AddHealthCheckEndpoint("ServerStatusEndpoint", @"https://api-res.gestioneambiente.net/health");
                //})
                //.AddInMemoryStorage();
            }

            //Aggiungo HttpContextAccessor per avere accesso all'utente autenticato tramite Contesto Http
            services.AddHttpContextAccessor();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ResourcesApiConfiguration resourcesApiConfiguration, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
            app.AddForwardHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // add an endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"{resourcesApiConfiguration.ApiBaseUrl}/swagger/{description.GroupName}/swagger.json", $"{resourcesApiConfiguration.ApiName} {description.GroupName}");
                }

                c.OAuthClientId(resourcesApiConfiguration.OidcSwaggerUIClientId);
                c.OAuthAppName(resourcesApiConfiguration.ApiName);
                c.OAuthUsePkce();
            });


            app.UseRouting();
            UseAuthentication(app);
            //Bypass CORS
            app.UseCors(x => x
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod()
            //.AllowCredentials()//mod
            .SetIsOriginAllowed((host) => true));

            app.UseAuthorization();

            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { 
                IsApiOnly=false,
                UseApiProblemDetailsException=true,
                BypassHTMLValidation=true,

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHub<NotificationHub>("/resourcesHub");
                endpoints.MapHub<BackgroundServicesHub>("/backgroundServicesHub");
                

                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                endpoints.MapHealthChecksUI(setup => 
                {
                    setup.AddCustomStylesheet("dotnet.css");
                });
            });
        }

        public virtual void RegisterDbContexts(IServiceCollection services)
        {
            services.AddDbContexts<AdminIdentityDbContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext, IdentityServerDataProtectionDbContext, AuditLog>(Configuration);
        }

        public virtual void RegisterResourcesDbContexts(IServiceCollection services)
        {
            services.AddResourcesDbContexts<ResourcesDbContext>(Configuration);
        }

        public virtual void RegisterAuthentication(IServiceCollection services)
        {
            services.AddApiAuthentication<AdminIdentityDbContext, UserIdentity, UserIdentityRole>(Configuration);
        }

        public virtual void RegisterAuthorization(IServiceCollection services)
        {
            services.AddAuthorizationPolicies();
        }

        public virtual void UseAuthentication(IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}
