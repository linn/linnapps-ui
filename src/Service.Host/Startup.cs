namespace Linn.LinnappsUi.Service.Host
{
    using System;
    using System.IdentityModel.Tokens.Jwt;

    using Autofac;
    using Autofac.Extensions.DependencyInjection;

    using Linn.Common.Authentication.Host.Extensions;
    using Linn.Common.Configuration;
    using Linn.LinnappsUi.IoC;
    using Linn.LinnappsUi.Persistence;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddLinnAuthentication(
                options =>
                    {
                        options.Authority = ConfigurationManager.Configuration["AUTHORITY_URI"];
                        options.CallbackPath = new PathString("/linnapps-ui/signin-oidc");
                    });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddRazorPagesOptions(options =>
                    {
                        options.Conventions.AllowAnonymousToFolder("/linnapps-ui");
                    });
            services.AddDbContext<ServiceDbContext>(options => options.UseOracle(this.GetConnectionString()));

            // Add Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AmazonCredentialsModule>();
            containerBuilder.RegisterModule<AmazonSqsModule>();
            containerBuilder.RegisterModule<LoggingModule>();
            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseBearerTokenAuthentication();

            app.UseMvc();
        }

        private string GetConnectionString()
        {
            var host = ConfigurationManager.Configuration["DATABASE_HOST"];
            var databaseName = ConfigurationManager.Configuration["DATABASE_NAME"];
            var userId = ConfigurationManager.Configuration["DATABASE_USER_ID"];
            var password = ConfigurationManager.Configuration["DATABASE_PASSWORD"];
#if DEBUG
            return $"Data Source={host};Sid={databaseName};UserId={userId};Password={password};Direct=true";
#else
            return $"Data Source={host};Sid={databaseName};UserId={userId};Password={password};License Key=trial:/app/bin/devart.data.oracle.key;Direct=true";
#endif
        }
    }
}