using System.Threading;
using System.Threading.Tasks;

namespace Education.Infrastructure.Interfaces.Proxies.Base
{
    public interface IProxyServer
    {
        #region Methods
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
        #endregion
    }
}