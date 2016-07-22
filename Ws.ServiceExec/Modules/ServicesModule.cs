using Autofac;
using Ws.ServiceExec.Service;

namespace Ws.ServiceExec.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder) 
        {
            builder.RegisterAssemblyTypes(typeof(AppService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}