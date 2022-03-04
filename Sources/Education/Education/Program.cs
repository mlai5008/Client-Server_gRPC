using Education.Bootloaders;
using Education.Communication.Logging;
using Education.ServerHosts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ninject;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;

namespace Education
{
    public class Program
    {
        #region Methods
        public static void Main(string[] args)
        {
            try
            {
                ConfigureBasicLogger();
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exc)
            {
                LoggingManager.Logger.Fatal(exc, "An unhandled exception occured during bootstrapping");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((configLogging) =>
                {
                    configLogging.ClearProviders();
                    configLogging.SetMinimumLevel(LogLevel.None);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IConfigurationBuilder>(conf => new ConfigurationBuilder());
                    services.AddSingleton<IKernel, StandardKernel>(k => new StandardKernel());
                    services.AddSingleton<AppBootstrapper>();

                    services.AddHostedService<ServerHost>();
                })
                .UseWindowsService();
        }

        private static void ConfigureBasicLogger()
        {
            LoggingManager.Logger = new LoggerConfiguration().WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .CreateLogger();
        } 
        #endregion
    }
}
