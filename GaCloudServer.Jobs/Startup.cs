using CrystalQuartz.Application;
using CrystalQuartz.AspNetCore;
using GaCloudServer.Admin.EntityFramework.Shared.DbContexts;
using GaCloudServer.Admin.EntityFramework.Shared.Extensions;
using GaCloudServer.BusinnessLogic.Extensions;
using GaCloudServer.BusinnessLogic.Hub;
using GaCloudServer.Jobs.Helpers;
using GaCloudServer.Jobs.Jobs;
using GaCloudServer.Jobs.Providers;
using GaCloudServer.Jobs.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Skoruba.AuditLogging.EntityFramework.Entities;
using System.Collections.Specialized;
using System.Text;

namespace GaCloudServer.Jobs
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment CurrentEnvironment { get; set; }

        public SingletonJobFactory jobFactory { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddMvc(options =>
                            options.EnableEndpointRouting = false
                        );

            services.Configure<IISServerOptions>(options =>
                options.AllowSynchronousIO = true
            );

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            //var apiConfiguration = Configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
            //services.AddSingleton(apiConfiguration);

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add DbContexts

            RegisterDbContexts(services);

            services.AddJobsResourcesRepository<ResourcesDbContext>();
            services.AddJobsResourcesServices<ResourcesDbContext>();

            services.AddAuditEventLogging<AdminAuditLogDbContext, AuditLog>(Configuration);
            services.AddTransient<IMailJobService, MailJobService>();

            //services.AddAuditEventLogging<AdminAuditLogDbContext, AuditLog>(Configuration);
            //services.AddTransient<IMailService, MailService>();

            //Quartz DI
            NameValueCollection properties = new NameValueCollection();
            if (CurrentEnvironment.IsDevelopment())
            {
                properties = QuartzHelpers.GetQuartzDevConfig();
            }
            else
            {
                properties = QuartzHelpers.GetQuartzProdConfig();
            }

            services.Configure<QuartzOptions>(Configuration.GetSection("Quartz"));

            services.AddSingleton<IJobFactory, JobFactory>();
            var instance = new StdSchedulerFactory(properties);
            services.AddSingleton<ISchedulerFactory>(instance);//, StdSchedulerFactory>();
            services.AddSingleton<QuartzJobRunner>();
            services.AddHostedService<QuartzHostedService>();

            services.AddScoped<MailJobs>();
            services.AddScoped<ScadJobs.GaAutorizzazioniScadenziarioJob>();
            services.AddScoped<ScadJobs.GaMezziScadenziarioJob>();
            services.AddScoped<ScadJobs.GaContrattiScadenziarioJob>();
            services.AddScoped<ScadJobs.GaDipendentiNoviScadenziarioJob>();
            services.AddScoped<ScadJobs.GaDipendentiTortonaScadenziarioJob>();
            services.AddScoped<ScadJobs.GaReclamiScadenziarioJob>();
            services.AddScoped<EmzJobs.EmzWhiteListJob>();
            services.AddScoped<GarbageJobs.GarbageUtenzeJob>();
            services.AddScoped<GarbageJobs.GarbagePartiteJob>();
            services.AddScoped<GarbageJobs.GarbageTipologieJob>();
            services.AddScoped<GarbageJobs.GarbageProvenienzeJob>();
            services.AddScoped<GarbageJobs.GarbageStatiJob>();
            services.AddScoped<GarbageJobs.GarbageTicketContactCenterJob>();
            services.AddScoped<GarbageJobs.GarbageTicketMagazzinoJob>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            loggerFactory.AddFile("Logs/mylog-{Date}.txt");

            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/jobsHub");
            });

            // app is IAppBuilder
            // Note: this code should come before app.UseCrystalQuartz
            app.Use(async (context, next) =>
            {
                var request = context.Request;
                var requestUri = request.Path;

                if (requestUri.ToString().StartsWith("/quartz"))
                {
                    var header = request.Headers["Authorization"];

                    if (!String.IsNullOrWhiteSpace(header))
                    {
                        var authHeader = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(header);

                        if ("Basic".Equals(authHeader.Scheme, StringComparison.OrdinalIgnoreCase))
                        {
                            string parameter = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter));
                            var parts = parameter.Split(':');

                            string userName = parts[0];
                            string password = parts[1];

                            bool isValidUser = userName == "admin" && password == "SrvGcL!!6985";
                            if (isValidUser)
                            {
                                await next();
                                return;
                            }
                        }
                    }

                    context.Response.StatusCode = 401;
                    context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"App\"";
                }
                else
                {
                    await next();
                }
            });

            var schedulerFactory = app.ApplicationServices.GetService<ISchedulerFactory>();
            var scheduler = schedulerFactory.GetScheduler().Result;
            app.UseCrystalQuartz(
                () => scheduler,
                new CrystalQuartzOptions {
                    AllowedJobTypes = new[]
                    { 
                        typeof(MailJobs),
                        typeof(ScadJobs.GaAutorizzazioniScadenziarioJob),
                        typeof(ScadJobs.GaMezziScadenziarioJob),
                        typeof(ScadJobs.GaDipendentiNoviScadenziarioJob),
                        typeof(ScadJobs.GaDipendentiTortonaScadenziarioJob),
                        typeof(ScadJobs.GaContrattiScadenziarioJob),
                        typeof(ScadJobs.GaReclamiScadenziarioJob),
                        typeof(EmzJobs.EmzWhiteListJob),
                        typeof(GarbageJobs.GarbageUtenzeJob),
                        typeof(GarbageJobs.GarbagePartiteJob),
                        typeof(GarbageJobs.GarbageTipologieJob),
                        typeof(GarbageJobs.GarbageStatiJob),
                        typeof(GarbageJobs.GarbageProvenienzeJob),
                        typeof(GarbageJobs.GarbageTicketContactCenterJob),
                        typeof(GarbageJobs.GarbageTicketMagazzinoJob),
                    }
                }
                );


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        public virtual void RegisterDbContexts(IServiceCollection services)
        {
            services.AddDbContexts<AdminAuditLogDbContext, ResourcesDbContext>(Configuration);
        }
    }
}
