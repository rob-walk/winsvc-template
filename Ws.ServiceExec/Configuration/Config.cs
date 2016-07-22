using System.Configuration;

namespace Ws.ServiceExec.Configuration
{
    public class Config : IConfig
    {
        public Config()
        {
            Environment = ConfigurationManager.AppSettings["environment"];
            JobServiceServiceName = ConfigurationManager.AppSettings["serviceName"];
            JobServiceServiceDescription = ConfigurationManager.AppSettings["serviceDescription"];
        }

        public string Environment { get; }
        public string JobServiceServiceName { get; }
        public string JobServiceServiceDescription { get; }
    }
}