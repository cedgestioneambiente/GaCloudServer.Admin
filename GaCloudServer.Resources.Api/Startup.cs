using GaCloudServer.Resources.Api.Configuration;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Resources;
using Skoruba.Duende.IdentityServer.Shared.Configuration.Helpers;
using System.IdentityModel.Tokens.Jwt;
using GaCloudServer.Admin.EntityFramework.Shared.DbContexts;
using GaCloudServer.Resources.Api.Mappers;
using GaCloudServer.Shared.Dtos.Identity;
using GaCloudServer.Shared.Dtos;
using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Identity.Extensions;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Identity;
using GaCloudServer.Admin.EntityFramework.Shared.Extensions;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.Resources.Api.Helpers;
using Microsoft.OpenApi.Models;
using GaCloudServer.Resources.Api.Configuration.Authorization;
using Skoruba.AuditLogging.EntityFramework.Entities;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Extensions;
using AutoWrapper;

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
            var resourcesApiConfiguration = Configuration.GetSection(nameof(ResourcesApiConfiguration)).Get<ResourcesApiConfiguration>();
            services.AddSingleton(resourcesApiConfiguration);

            // Add DbContexts
            RegisterDbContexts(services);
            RegisterResourcesDbContexts(services);

            services.AddDataProtection<IdentityServerDataProtectionDbContext>(Configuration);

            services.AddScoped<ControllerExceptionFilterAttribute>();
            services.AddScoped<IApiErrorResources, ApiErrorResources>();

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

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(resourcesApiConfiguration.ApiVersion, new OpenApiInfo { Title = resourcesApiConfiguration.ApiName, Version = resourcesApiConfiguration.ApiVersion });

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
            });

            services.AddAuditEventLogging<AdminAuditLogDbContext, AuditLog>(Configuration);

            services.AddIdSHealthChecks<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminIdentityDbContext, AdminLogDbContext, AdminAuditLogDbContext, IdentityServerDataProtectionDbContext,ResourcesDbContext>(Configuration, resourcesApiConfiguration);

            services
                .AddHealthChecksUI(setupSettings: setup => {
                    setup.AddHealthCheckEndpoint("ServerStatusEndpoint", "https://localhost:44312/health");
                })
                .AddInMemoryStorage();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ResourcesApiConfiguration resourcesApiConfiguration)
        {
            app.AddForwardHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{resourcesApiConfiguration.ApiBaseUrl}/swagger/v1/swagger.json", resourcesApiConfiguration.ApiName);

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
            .SetIsOriginAllowed(origin => true));

            app.UseAuthorization();

            app.UseApiResponseAndExceptionWrapper();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                

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
