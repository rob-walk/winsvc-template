using Autofac;
using Devon.DSurv.Ws.ServiceExec.Modules;
using Ws.ServiceExec.Modules;

namespace Ws.ServiceExec.Configuration
{
    public class Bootstrapper
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(new Config())
                .SingleInstance()
                .AsImplementedInterfaces();

            builder.RegisterType<ServiceRunner>()
                .AsImplementedInterfaces();

            RegisterAllModules(builder);

            var container = builder.Build();
            
            return container;
        }

        private static void RegisterAllModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new LoggingModule());

            builder.RegisterModule(new ServicesModule());            
        }
    }
}