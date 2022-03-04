using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Education.Infrastructure.Interfaces.Settings.Builders
{
    public interface IAppSettingsBuilder
    {
        #region Methods
        void CreateConfiguration(string pathToConfigFile);
        TSettingsModel BuildSettingsModel<TSettingsModel>(string sectionKey) where TSettingsModel : class;
        TSettingsModel BuildSettingsModel<TSettingsModel>(IConfigurationSection section) where TSettingsModel : class;
        IList<TSettingsModel> BuildSettingsModels<TSettingsModel>(string sectionKey) where TSettingsModel : class;
        #endregion
    }
}