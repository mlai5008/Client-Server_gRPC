using Education.Domain.Settings.Models;
using Education.Infrastructure.Constants.Settings;
using Education.Infrastructure.Interfaces.Settings.Builders;
using Education.Infrastructure.Interfaces.Settings.Models;
using Education.Infrastructure.Interfaces.Settings.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Education.Composite.Settings.Providers
{
    public class EnvironmentSettingsProvider : BaseAppSettingsProvider<IAppSettingsBuilder>, IEnvironmentSettingsProvider
    {
        #region ctor
        public EnvironmentSettingsProvider(IAppSettingsBuilder appSettingsBuilder) : base(appSettingsBuilder)
        { }
        #endregion

        #region Properties
        public IServerSettingsModel ServerSettings { get; private set; }
        public IList<IChildServiceSettingsModel> ChildrenServicesSettings { get; private set; }
        #endregion

        #region Methods
        public override void InitializeProviderProperties()
        {
            ServerSettings = SettingsBuilder.BuildSettingsModel<ServerSettingsModel>(SettingsKeyConstants.ServerSettingsKey);
            ChildrenServicesSettings = SettingsBuilder.BuildSettingsModels<ChildServiceSettingsModel>(SettingsKeyConstants.ChildrenServicesSettingsKey).Cast<IChildServiceSettingsModel>().ToList();
        }
        #endregion
    }
}