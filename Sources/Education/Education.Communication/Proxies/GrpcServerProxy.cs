using Education.Communication.Logging;
using Education.Infrastructure.Interfaces.CommunicationServices;
using Education.Infrastructure.Interfaces.Proxies;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Communication.Proxies
{
    public class GrpcServerProxy : IGrpcServerProxy
    {
        #region Fields
        private readonly IGrpcServer _server;
        #endregion

        #region Ctor
        public GrpcServerProxy(IGrpcServer server)
        {
            _server = server;
            InitializeServer();
        }
        #endregion

        #region Methods
        private void InitializeServer()
        {
            _server.Initialize();
            SubscribeOnServerEvents();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                await RunServer(cancellationToken);
            }
            catch (Exception ex)
            {
                LoggingManager.Logger.Fatal(ex.Message);
                throw ex;
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _server.StopAsync();
        }

        private void SubscribeOnServerEvents()
        {
            _server.ServerStarted += OnServerStarted;
            _server.ServerStopped += OnServerStopped;
        }

        private void OnServerStarted(object sender, EventArgs e)
        {
            LoggingManager.Logger.Information("Server was started on {Host}:{Port}", _server.Host, _server.Port);
        }

        private void OnServerStopped(object sender, EventArgs e)
        {
            LoggingManager.Logger.Information("{TypeName}: server is stop at {Host}:{Port}.", GetType().Name, _server.Host, _server.Port);
        }

        private async Task RunServer(CancellationToken cancellationToken)
        {
            LoggingManager.Logger.Information("Starting the server...");
            //await Task.Run(() => ServiceServer.StartAsync(cancellationToken), cancellationToken);
            await _server.StartAsync(cancellationToken);
        } 
        #endregion
    }
}