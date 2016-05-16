using System;
using System.Diagnostics;
using d.Log.Extentions;
using d.Log.Interfaces;

namespace d.Log.Loggers
{
    public class DebugLogger: ILog
    {
        public string ApplicationName { get; set; }

        public DebugLogger()
        {
            ApplicationName = "ILog.DebugLogger";
        }

        private string DecorateString(string message)
        {
            return string.Concat("==============================================", Environment.NewLine,
                                    ApplicationName, Environment.NewLine,  message, Environment.NewLine,
                                 "==============================================", Environment.NewLine);
        }
        
        public void Error(Exception ex)
        {
           Error("", ex);
        }

        public void Error(string message, Exception ex)
        {
            if (System.Diagnostics.Debugger.IsAttached)
                Debug.WriteLine(DecorateString(string.Concat(message,": Error ", Environment.NewLine, ex.ToStringEx() )));
        }

        public void Info(string logMessage)
        {
            if (System.Diagnostics.Debugger.IsAttached)
                Debug.WriteLine(DecorateString(string.Concat(": Info ",Environment.NewLine, logMessage)));
        }
        
        public void Log(System.Diagnostics.EventLogEntryType entry, string moduleName, string logMessage)
        {
            if (System.Diagnostics.Debugger.IsAttached)
                Debug.WriteLine(DecorateString(string.Concat(": Info ", Environment.NewLine, moduleName, Environment.NewLine, logMessage)));
        }

        
    }
}
