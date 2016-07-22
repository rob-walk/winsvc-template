using System;
using System.Reflection;

namespace Ws.ConsoleDebugger.ExceptionHandler
{
    public static class ApplicationExceptionHandler
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Register()
        {
            AppDomain.CurrentDomain.UnhandledException += Handle;
        }

        public static void Handle(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;

            if (exception == null)
                return;

            do
            {
                Log.Fatal(exception.Message, exception);

                exception = exception.InnerException;
            } while (exception != null);
        }
    }
}
