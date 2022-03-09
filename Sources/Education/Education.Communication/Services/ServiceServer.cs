using Education.Common.ServiceContracts.ServiceContract;
using Education.Common.ServiceContracts.ServiceEntityContract;
using Education.Communication.Logging;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Education.Communication.Services
{
    public class ServiceServer : ServiceContract.ServiceContractBase
    {
        #region Ctor
        public ServiceServer()
        {
            ServiceDefinition = ServiceContract.BindService(this);
        } 
        #endregion

        #region Properties
        public ServerServiceDefinition ServiceDefinition { get; private set; }
        #endregion

        #region Methods
        public override Task<ConnectResponse> Connect(EmptyContract request, ServerCallContext context)
        {
            LoggingManager.Logger.Information("Client connected at {dateTime}", DateTime.Now);
            return Task.FromResult(new ConnectResponse(){ConnectionResult = true, ServiceState = ServiceState.Connected}) ;
        } 
        #endregion
    }
}