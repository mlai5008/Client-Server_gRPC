namespace Education.Infrastructure.Interfaces.Settings.Models
{
    public interface IChildServiceSettingsModel : ISettingsModel
    {
        #region Properties
        /// <summary>
        /// Sets or returns setting of the name a child service
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Sets or returns setting of the host a child service
        /// </summary>
        string Host { get; }
        /// <summary>
        /// Sets or returns setting of the port a child service
        /// </summary>
        int Port { get; }
        #endregion
    }
}