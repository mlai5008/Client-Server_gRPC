using Education.Composite.Settings.Builders;
using Education.Composite.Settings.Providers;
using Education.Infrastructure.Interfaces.Settings.Builders;
using Education.Infrastructure.Interfaces.Settings.Providers;
using Ninject.Modules;

namespace Education.Composite
{
    public class CompositeModule : NinjectModule
    {
        #region Methods
        public override void Load()
        {
            SetBindings();
        }

        private void SetBindings()
        {
            SetBuilderBindings();
            SetProviderBindings();
        }

        private void SetBuilderBindings()
        {
            Bind<IAppSettingsBuilder, AppSettingsBuilder>().To<AppSettingsBuilder>();
        }

        private void SetProviderBindings()
        {
            Bind<IEnvironmentSettingsProvider, EnvironmentSettingsProvider>().To<EnvironmentSettingsProvider>();
        }
        #endregion
    }
}