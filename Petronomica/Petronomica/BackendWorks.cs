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

namespace Petronomica
{
    public class BackendWorks
    {
        public BackendWorks(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
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
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "backendlogger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
            app.UseResponseCompression();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Development}/{action=Index}/{id?}");
            });
            app.Use(async (context, next) =>
            { 
             
                await next.Invoke();
            });
            app.Run(async (context) =>
            {
               // logger.LogInformation("Processing request {0}", context.Request.Path);
                logger.LogInformation("Identity{0}", context.User.Identity);
              
                context.Response.ContentType = "text/html; charset=utf-8";

                await context.Response.WriteAsync(context.Request.Headers.ToString());
              
            });

        }
    }
}
