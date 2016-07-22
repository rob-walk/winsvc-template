namespace Ws.ServiceExec
{
    public class ServiceRunner : IServiceRunner
    {
        static ServiceRunner()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public ServiceRunner()
        {
            // any configurations 
        }

        public void Dispose()
        {
        
        }
    }
}