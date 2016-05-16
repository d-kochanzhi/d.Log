using System;
using d.Log.Interfaces;

namespace d.Log.Loggers
{
    public class LogAggregator : ILog
    {
        private ILog[] loggers;

        public string ApplicationName { get; set; }

        public LogAggregator(ILog[] loggers)
        {
            this.loggers = loggers;
        }

        private void SetApplicationName()
        {
            if (!String.IsNullOrEmpty(ApplicationName))
            {
                Array.ForEach(loggers, logger => logger.ApplicationName = ApplicationName);
            }
        }

        public void Error(Exception ex)
        {
            SetApplicationName();
            Array.ForEach(loggers, logger => logger.Error(ex));
        }

        public void Error(string message, Exception ex)
        {
            SetApplicationName();
            Array.ForEach(loggers, logger => logger.Error(message, ex));
        }


        public void Info(string logMessage)
        {
            SetApplicationName();
            Array.ForEach(loggers, logger => logger.Info(logMessage));
        }

       

        public void Log(System.Diagnostics.EventLogEntryType entry, string moduleName, string logMessage)
        {
            SetApplicationName();
            Array.ForEach(loggers, logger => logger.Log(entry, moduleName, logMessage));
        }

       
    }
}
