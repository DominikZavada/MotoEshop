using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MotoEshop.Models.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost webHost = CreateWebHostBuilder(args).Build();

            using (var scope = webHost.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var dbContext = serviceProvider.GetRequiredService<EshopDBContext>();
                DbInitializer.Initialize(dbContext);
            }

            DbInitializer.EnsureRoleCreated(webHost.Services);
            DbInitializer.EnsureAdminCreated(webHost.Services);


            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, Logging) =>
                {
                    Logging.ClearProviders();
                    Logging.AddConsole();
                    Logging.AddEventSourceLogger();
                    Logging.AddEventLog(new Microsoft.Extensions.Logging.EventLog.EventLogSettings()
                    {
                        SourceName = "UTB.eshop",
                        LogName = "Application"
                    });
                });
    }
}
