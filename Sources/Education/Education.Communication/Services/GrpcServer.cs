using Education.Communication.Logging;
using Education.Communication.Services.Base;
using Education.Infrastructure.Constants.Settings;
using Education.Infrastructure.Interfaces.CommunicationServices;
using Education.Infrastructure.Interfaces.Settings.Providers;

namespace Education.Communication.Services
{
    public class GrpcServer : BaseGrpcServerService<ServiceServer>, IGrpcServer
    {
        #region Fields
        private readonly IEnvironmentSettingsProvider _environmentSettings; 
        #endregion

        #region Ctor
        public GrpcServer() : base() { }

        public GrpcServer(ServiceServer serviceServer, IEnvironmentSettingsProvider environmentSettings) : this()
        {
            _environmentSettings = environmentSettings;
            ServerService = serviceServer;
        }
        #endregion

        #region Methods
        public override void ConfigureServiceDefinition()
        {
            Server.Services.Add(ServerService.ServiceDefinition);
        }

        public void Initialize()
        {
            InitializeSettings();
            LoggingManager.Logger.Information("{Instance}: creating the gRPC server...", nameof(GrpcServer));
            CreateServer();
            ConfigureServerPort();
            ConfigureServiceDefinition();
        }

        private void InitializeSettings()
        {
            _environmentSettings.Initialize(ConfigFilePathConstants.EnvironmentSettingsConfig);
            Host = _environmentSettings.ServerSettings.Host;
            Port = _environmentSettings.ServerSettings.Port;
            Name = _environmentSettings.ServerSettings.Name;
        } 
        #endregion
    }
}