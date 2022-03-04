using System;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Infrastructure.Interfaces.CommunicationServices
{
    public interface IServer
    {
        #region Properties
        string Host { get; }
        int Port { get; }
        bool IsStarted { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Start the server
        /// </summary>
        Task StartAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Stops the server async
        /// </summary>
        /// <returns></returns>
        Task StopAsync();
        #endregion

        #region Events
        /// <summary>
        /// Occurs when server started
        /// </summary>
        event EventHandler ServerStarted;

        /// <summary>
        /// Occurs when server stopped
        /// </summary>
        event EventHandler ServerStopped;
        #endregion
    }
}