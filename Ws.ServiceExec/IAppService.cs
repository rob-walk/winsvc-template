using log4net;

namespace Ws.ServiceExec
{
    public interface IAppService
    {
        IConfig Configuration { get; }
        ILog Log { get; }
    }
}
