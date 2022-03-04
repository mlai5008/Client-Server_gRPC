namespace Education.Infrastructure.Interfaces.CommunicationServices
{
    public interface IGrpcServer : IServer
    {
        #region Methods
        /// <summary>
        /// Define a service for the server
        /// </summary>
        void ConfigureServiceDefinition();
        /// <summary>
        /// Initialize the server
        /// </summary>
        void Initialize();
        #endregion
    }
}