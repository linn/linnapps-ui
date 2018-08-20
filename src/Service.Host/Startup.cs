namespace Linn.LinnappsUi.Service.Host
{
    using System;

    using Autofac;
    using Autofac.Extensions.DependencyInjection;

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

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ServiceDbContext>(options => options.UseOracle(this.GetConnectionString()));

            // Add Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AmazonCredentialsModule>();
            containerBuilder.RegisterModule<AmazonSqsModule>();
            containerBuilder.RegisterModule<LoggingModule>();
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

            app.UseMvc();
        }

        private string GetConnectionString()
        {
            var host = ConfigurationManager.Configuration["DATABASE_HOST"];
            var databaseName = ConfigurationManager.Configuration["DATABASE_NAME"];
            var userId = ConfigurationManager.Configuration["DATABASE_USER_ID"];
            var password = ConfigurationManager.Configuration["DATABASE_PASSWORD"];
            var databasePort = ConfigurationManager.Configuration["DATABASE_PORT"];

            return $"Server={host};Port={databasePort};Sid={databaseName};UserId={userId};Password={password};License Key=trial:devart.data.oracle.key";
        }
    }
}
