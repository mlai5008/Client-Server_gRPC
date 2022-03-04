namespace Education.Infrastructure.Interfaces.Settings.Providers
{
    public interface IAppSettingsProvider
    {
        #region Methods
        void InitializeSettingsBuilder(string configFilePath);
        void InitializeProviderProperties();
        #endregion
    }
}