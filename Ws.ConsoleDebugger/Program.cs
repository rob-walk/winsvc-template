using System;
using System.Reflection;
using Autofac;
using Ws.ConsoleDebugger.ExceptionHandler;
using Ws.ServiceExec;
using Ws.ServiceExec.Configuration;

namespace Ws.ConsoleDebugger
{
    class Program
    {
        private static IContainer _container;

        static void Main(string[] args)
        {
            ApplicationExceptionHandler.Register();

            Bootstrap();

            var appService = _container.Resolve<IAppService>();

            SetTitlebar(appService.Configuration);

            using (_container.Resolve<IServiceRunner>())
            {
                appService.Log.Debug("Debugger started");
                Console.ReadKey();
            }
        }

        private static void Bootstrap()
        {
            var bootstrap = new Bootstrapper();

            _container = bootstrap.BuildContainer();
        }

        private static void SetTitlebar(IConfig config)
        {
            var name = Assembly.GetExecutingAssembly().GetName().Name;

            Console.Title = string.Format("{0} - {1}", name, config.Environment);
        }
    }
}
