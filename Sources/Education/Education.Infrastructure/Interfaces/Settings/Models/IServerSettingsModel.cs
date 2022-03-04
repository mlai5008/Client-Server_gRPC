namespace Education.Infrastructure.Interfaces.Settings.Models
{
    /// <summary>
    /// Interface for the model of server settings
    /// </summary>
    public interface IServerSettingsModel : ISettingsModel
    {
        #region Properties
        /// <summary>
        /// Returns the name a main server
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Sets or returns setting of the host a main server
        /// </summary>
        string Host { get; }
        /// <summary>
        /// Sets or returns setting of the port a main server
        /// </summary>
        int Port { get; }
        #endregion
    }
}