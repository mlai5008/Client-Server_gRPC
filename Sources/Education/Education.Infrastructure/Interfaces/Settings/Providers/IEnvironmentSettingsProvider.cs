using System.Collections.Generic;
using Education.Infrastructure.Interfaces.Settings.Models;

namespace Education.Infrastructure.Interfaces.Settings.Providers
{
    public interface IEnvironmentSettingsProvider : IAppSettingsProvider
    {
        #region Properties
        IServerSettingsModel ServerSettings { get; }

        IList<IChildServiceSettingsModel> ChildrenServicesSettings { get; }
        #endregion

        #region Methods
        void Initialize(string configFilePath);
        #endregion
    }
}