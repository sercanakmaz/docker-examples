using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PerformanceProfiling
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
              .ConfigureHostConfiguration(config => { config.AddEnvironmentVariables("ASPNETCORE_"); })
              .ConfigureAppConfiguration((hostingContext, config) =>
              {
                  ConfigureApp(hostingContext, config);
            
                  Console.WriteLine(hostingContext.HostingEnvironment.EnvironmentName);
              })
              .ConfigureServices(ConfigureServices).ConfigureLogging(ConfigureLogging);

            await builder.RunConsoleAsync();
        }

        private static void ConfigureLogging(HostBuilderContext hostingContext, ILoggingBuilder logging)
        {
            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            logging.AddConsole();
        }
        private static void ConfigureApp(HostBuilderContext hostingContext, IConfigurationBuilder config)
        {
            config
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", false, true)
                .AddEnvironmentVariables();
        }

        private static void ConfigureServices(HostBuilderContext hostingContext, IServiceCollection services)
        {
            services.AddHostedService<WorkerHost>();
        }
    }
}
