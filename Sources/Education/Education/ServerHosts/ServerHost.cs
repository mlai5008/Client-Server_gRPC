using Education.Bootloaders;
using Education.Communication.Logging;
using Education.Infrastructure.Interfaces.Proxies;
using Microsoft.Extensions.Hosting;
using Ninject;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Education.ServerHosts
{
    public class ServerHost : BackgroundService
    {
        #region Fields
        private readonly IKernel _container;
        private readonly AppBootstrapper _bootstrapper;
        private IGrpcServerProxy _grpcServerProxy;
        #endregion

        #region Ctor
        public ServerHost(IKernel container, AppBootstrapper bootstrapper)
        {
            _container = container;
            _bootstrapper = bootstrapper;
        }
        #endregion

        #region Methods
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                LoggingManager.Logger.Information("Loading the host...");

                await DeployGrpcServerProxy(stoppingToken);
            }
            catch (Exception ex)
            {
                LoggingManager.Logger.Fatal("Error while the service host loads:\n{Exception}\nService should be stopped!", ex.Message);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            if (_grpcServerProxy != null) await _grpcServerProxy.StopAsync(stoppingToken);
            await base.StopAsync(stoppingToken);
        }

        private async Task DeployGrpcServerProxy(CancellationToken stoppingToken)
        {
            LoggingManager.Logger.Information("Deploying the proxy server...");
            _grpcServerProxy = _container.Get<IGrpcServerProxy>();

            if (_grpcServerProxy == null) throw new Exception("The host can't find the proxy server for hosting");

            await _grpcServerProxy.StartAsync(stoppingToken);
            LoggingManager.Logger.Information("Proxy Server was deployed");
        } 
        #endregion
    }
}
