using System.ServiceProcess;
using Autofac;
using Ws.ServiceExec;
using Ws.ServiceExec.Configuration;
using IContainer = Autofac.IContainer;

namespace Ws.Shell
{
    partial class WindowsService : ServiceBase
    {
        private static IContainer _container;
        private IServiceRunner _serviceRunner;

        public WindowsService()
        {
            InitializeComponent();

            Bootstrap();
        }

        protected override void OnStart(string[] args)
        {
            _serviceRunner = _container.Resolve<IServiceRunner>();
        }

        protected override void OnStop()
        {
            _serviceRunner.Dispose();
        }

        private static void Bootstrap()
        {
            var bootstrap = new Bootstrapper();

            _container = bootstrap.BuildContainer();
        }
    }
}
