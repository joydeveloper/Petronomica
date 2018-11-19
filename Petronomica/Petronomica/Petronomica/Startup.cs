using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Petronomica.Data;
using Petronomica.Models;
using PetronomicaServices;
using SharedServices;
using WebEssentials.AspNetCore.Pwa;
namespace Petronomica
{
    //TODO project version,description etc
    //TODO error pages,error logger
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
            //services.AddSingleton<IOrderRepository, OrderRepositoryMock>();
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
            app.UseCookiePolicy();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseAuthentication();
        }
        private void ConfigureCommonServices(IServiceCollection services)
        {


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>((config =>
            {

                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireDigit = true;
            }))
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            services.AddSingleton<IMessageSender, EmailMessageSender>();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();
            //services.AddProgressiveWebApp(new PwaOptions
            //{
            //    Strategy = ServiceWorkerStrategy.CacheFirst,
            //    CacheId = "v5",
            //    RoutesToPreCache = "~/css/site.css, ~/images",
            //    RegisterServiceWorker = true
            //});
         
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IOrderRepo, HardCodeOrderRepository>();
        }
    }
}
