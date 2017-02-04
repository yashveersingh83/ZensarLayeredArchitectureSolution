using System;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Zensar.Common
{
    public class Logger : ILogger
    {

        static Logger()
        {

            try
            {
                var test = Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Writer;
            }
            catch
            {

                IConfigurationSource config = ConfigurationSourceFactory.Create();

                Microsoft.Practices.EnterpriseLibrary.Logging.Logger.SetLogWriter(
                    new LogWriterFactory(config).Create(), false);

                new Logger().LogInformation("logger init done in constructor");
            }





        }
        public void LogException(Exception ex)
        {
            var entry = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry
            {
                Message = ex.ToString(),
                Severity = TraceEventType.Error
            };

            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(entry);
        }

        public void LogInformation(String message)
        {
            var entry = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry { Message = message };

            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(entry);
        }

        public void LogExceptionAsWarning(Exception ex)
        {
            var entry = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry
            {
                Message = ex.ToString(),
                Severity = TraceEventType.Warning
            };

            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(entry);
        }
    }
}