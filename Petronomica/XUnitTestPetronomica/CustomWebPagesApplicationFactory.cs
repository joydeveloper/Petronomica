using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Petronomica;
using ReUse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XUnitTestPetronomica
{
   
    public class CustomWebPagesApplicationFactory<TStartup>: WebApplicationFactory<BackendWorks>
    {
        //public CustomWebPagesApplicationFactory(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
       // public IConfiguration Configuration { get; }
      
        public ILoggerFactory _loggerFactory { get; private set; }
        public ILogger _logger { get; private set; }
        public TestServer testServer;
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            
          
            return base.CreateWebHostBuilder();
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
           
            builder.ConfigureServices(services =>
            {
                testServer = new TestServer(builder);
                var serviceProvider = new ServiceCollection()
                   //     .AddEntityFrameworkInMemoryDatabase()
                   .BuildServiceProvider();

                //// Add a database context (ApplicationDbContext) using an in-memory
                //// database for testing.
                //services.AddDbContext<CatalogContext>(options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryDbForTesting");
                //    options.UseInternalServiceProvider(serviceProvider);
                //});

                //services.AddDbContext<AppIdentityDbContext>(options =>
                //{
                //    options.UseInMemoryDatabase("Identity");
                //    options.UseInternalServiceProvider(serviceProvider);
                //});

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    //var db = scopedServices.GetRequiredService<CatalogContext>();
                    _loggerFactory = scopedServices.GetRequiredService<ILoggerFactory>();

                    _logger = scopedServices
                     .GetRequiredService<ILogger<CustomWebPagesApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    //     db.Database.EnsureCreated();

                    try
                    {
                        _loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "test.txt"));
                        _logger = _loggerFactory.CreateLogger("FileLogger");
                        // Seed the database with test data.
                        //CatalogContextSeed.SeedAsync(db, loggerFactory).Wait();
                    }
                    catch (Exception ex)
                    {
                        //  logger.LogError(ex, $"An error occurred seeding the " +
                        //    "database with test messages. Error: {ex.Message}");
                    }
                }

            });
        }


    }
}
