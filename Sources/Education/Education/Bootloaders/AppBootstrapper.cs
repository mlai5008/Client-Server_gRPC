using Education.Communication.Logging;
using Education.Infrastructure.Constants.Any;
using Education.Infrastructure.Constants.Logger;
using Ninject;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.IO;

namespace Education.Bootloaders
{
    public class AppBootstrapper
    {
        #region Fields
        private readonly IKernel _container;
        private readonly string _currentDay = DateTime.Now.ToString(LoggerConstants.FolderLogNameFormat);
        private readonly string _currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
        #endregion

        #region Ctor
        public AppBootstrapper(IKernel container)
        {
            _container = container;
            ConfigureLogger();
            LoadModules();
        }
        #endregion

        #region Methods
        private void ConfigureLogger()
        {
            LoggingManager.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File(Path.Combine(_currentAppDirectory, LoggerConstants.BaseAppLoggingDirectoryNameConstant, _currentDay, LoggerConstants.AppLogFife))
                .CreateLogger();
        }

        private void LoadModules()
        {
            LoggingManager.Logger.Information("Modules loading ...");
            _container.Load(AnyConstants.AnyDll);
            LoggingManager.Logger.Information("Modules loaded");
        }
        #endregion
    }
}