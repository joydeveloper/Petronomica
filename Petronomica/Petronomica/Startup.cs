using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebEssentials.AspNetCore.Pwa;

namespace Petronomica
{
    //TODO project version,description etc
    //TODO error pages
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCommonServices(services);
            // services.AddSingleton<IOrderRepository, OrderRepositoryMock>();
        }
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            ConfigureCommonServices(services);
            // services.AddSingleton<IOrderRepository, OrderRepositoryMock>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            ILogger WLogger = loggerFactory.CreateLogger("Warning");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
               
            }
            app.UseStatusCodePagesWithReExecute("/errors/{0}.html");
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
        private void ConfigureCommonServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();
            services.AddProgressiveWebApp(new PwaOptions
            {
                Strategy = ServiceWorkerStrategy.CacheFirst,
                CacheId = "v3",
                RoutesToPreCache = "~/css/site.css, ~/images",
            RegisterServiceWorker = true });
            services.AddAutoMapper();
            services.AddSingleton<IConfiguration>(Configuration);
        }
    }
}
