using Education.Communication.Logging;
using Education.Infrastructure.Interfaces.CommunicationServices;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Communication.Services.Base
{
    public abstract class BaseGrpcServerService<TGrpcServerService> : IServer where TGrpcServerService : class
    {
        #region Constants
        /// <summary>
        /// Message default size 4MB
        /// </summary>
        private const int DefaultReceiveMessageLength = 1024 * 1024 * 4;
        #endregion

        #region Field
        private readonly IEnumerable<ChannelOption> _serviceChannelOptions;
        #endregion

        #region ctor
        protected BaseGrpcServerService()
        {
            _serviceChannelOptions = new List<ChannelOption>
            {
                new ChannelOption(ChannelOptions.MaxReceiveMessageLength, DefaultReceiveMessageLength),
            };
        }
        #endregion

        #region Properties
        protected Server Server { get; set; }
        public TGrpcServerService ServerService { get; protected set; }
        public string Name { get; protected set; }
        public string Host { get; protected set; }
        public int Port { get; protected set; }
        public bool IsStarted { get; protected set; }
        #endregion

        #region Methods
        #region abstract
        /// <summary>
        /// Define a service for the server
        /// </summary>
        public abstract void ConfigureServiceDefinition();
        #endregion

        #region virtual
        /// <summary>
        /// Creates the new instance of <see cref=" Grpc.Core.Server"/>, sets channel options and also sets host and port
        /// </summary>
        public virtual void CreateServer()
        {
            Server = new Server(_serviceChannelOptions);
        }

        public virtual void ConfigureServerPort()
        {
            Server.Ports.Add(new ServerPort(Host, Port, ServerCredentials.Insecure));
        }
        #endregion

        /// <summary>
        /// Starting the server
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                try
                {
                    Server.Start();
                    IsStarted = true;
                    ServerStarted?.Invoke(this, EventArgs.Empty);
                }
                catch (RpcException ex)
                {
                    LoggingManager.Logger.Information("{Message} {Type}: error when the gRPC server start...", ex.Message, typeof(BaseGrpcServerService<TGrpcServerService>));
                    throw;
                }
            }, cancellationToken);
        }

        public async Task StopAsync()
        {
            await Server.ShutdownAsync();
            ServerStopped?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Events
        public event EventHandler ServerStarted;
        public event EventHandler ServerStopped;
        #endregion
    }
}