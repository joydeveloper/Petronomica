using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Petronomica.Services;
using Petronomica.Models;
using ReUse;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Petronomica.ReUse;
using WebEssentials.AspNetCore.Pwa;

namespace Petronomica
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceWorker(new PwaOptions
            {
                Strategy = ServiceWorkerStrategy.CacheFirst,
                CacheId = "v3",
                RoutesToPreCache = "~/css/site.css, ~/js/app.js,~/images"
            });
            services.AddTransient<IPasswordValidator<User>,
                    CustomPasswordValidator>(serv => new CustomPasswordValidator(6));
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>((config =>
            {

                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireDigit = true;
            }))
                .AddEntityFrameworkStores<ApplicationContext>()
               .AddDefaultTokenProviders();
            services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<MessageService>();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMvc();
            services.AddProgressiveWebApp();
    
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, MessageService messageService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
            app.UseSession();
            app.UseHttpsRedirection();
            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("startup.html");
            //app.UseDefaultFiles(options);
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Use(async (context, next) =>
            {
                context.Items["text"] = "Text from HttpContext.Items";
                await next.Invoke();
            });
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                logger.LogInformation("Processing request {0}", context.Request.Path);
                if (context.Request.Cookies.ContainsKey("guest"))
                {
                    await context.Response.WriteAsync("I");

                }
                else
                context.Response.Redirect("startup.html");
            });

        }
    }
}
