using Education.Infrastructure.Interfaces.Settings.Builders;
using Education.Infrastructure.Interfaces.Settings.Providers;

namespace Education.Composite.Settings.Providers
{
    public abstract class BaseAppSettingsProvider<TAppSettingsBuilder> : IAppSettingsProvider where TAppSettingsBuilder : IAppSettingsBuilder
    {
        #region Fields
        private readonly TAppSettingsBuilder _appSettingsBuilder;
        private string _configFilePath;
        #endregion

        #region ctor
        public BaseAppSettingsProvider(TAppSettingsBuilder appSettingsBuilder)
        {
            _appSettingsBuilder = appSettingsBuilder;
        }
        #endregion

        #region Properties
        public TAppSettingsBuilder SettingsBuilder => _appSettingsBuilder;
        #endregion

        #region Methods
        public virtual void Initialize(string configFilePath)
        {
            _configFilePath = configFilePath;
            InitializeSettingsBuilder(configFilePath);
            InitializeProviderProperties();
        }

        public virtual void InitializeSettingsBuilder(string configFilePath)
        {
            _appSettingsBuilder.CreateConfiguration(configFilePath);
        }

        public abstract void InitializeProviderProperties();
        #endregion
    }
}