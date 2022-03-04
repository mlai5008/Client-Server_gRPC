using Education.Infrastructure.Interfaces.Settings.Models;

namespace Education.Domain.Settings.Models
{
    public class ServerSettingsModel : IServerSettingsModel
    {
        #region Properties
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        #endregion
    }
}