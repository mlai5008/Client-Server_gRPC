using Education.Communication.Proxies;
using Education.Communication.Services;
using Education.Infrastructure.Interfaces.CommunicationServices;
using Education.Infrastructure.Interfaces.Proxies;
using Ninject.Modules;

namespace Education.Communication
{
    public class CommunicationModule : NinjectModule
    {
        #region Methods
        public override void Load()
        {
            SetBindings();
        }

        private void SetBindings()
        {
            SetProxyBindings();
            SetServerBindings();
        }

        private void SetProxyBindings()
        {
            Bind<IGrpcServerProxy, GrpcServerProxy>().To<GrpcServerProxy>().InSingletonScope();
        }

        private void SetServerBindings()
        {
            Bind<IGrpcServer, GrpcServer>().To<GrpcServer>().InSingletonScope();
            Bind<ServiceServer>().ToSelf();
        }
        #endregion
    }
}