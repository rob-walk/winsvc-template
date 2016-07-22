using System;
using System.Configuration;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;

namespace Ws.ServiceExec.Helper
{
    public static class ServiceInstallerHelpers
    {
        public static void SetServiceInstallerValues(ServiceInstaller serviceInstaller, Type projectInstallerType)
        {
            serviceInstaller.Description = GetConfigurationValue(Constants.ServiceDescription, projectInstallerType);

            serviceInstaller.DisplayName = string.Format("{0} ({1})",
                GetConfigurationValue(Constants.ServiceDisplayName, projectInstallerType), 
                GetConfigurationValue(Constants.Environment, projectInstallerType));

            serviceInstaller.ServiceName = string.Format("{0}{1}", 
                GetConfigurationValue(Constants.ServiceName, projectInstallerType),
                GetConfigurationValue(Constants.Environment, projectInstallerType).ToUpper());
        }

        private static string GetConfigurationValue(string key, Type type)
        {
            // type type is a any class contained the windows service project
            var service = Assembly.GetAssembly(type);
            var config = ConfigurationManager.OpenExeConfiguration(service.Location);

            if (config.AppSettings.Settings[key] == null)
            {
                throw new IndexOutOfRangeException(string.Format("Settings collection does not contain the requested key: {0}. Check the configuration and spelling.", key));
            }

            return config.AppSettings.Settings[key].Value;
        }
    }
}
