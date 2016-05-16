using System;
using System.Diagnostics;
using d.Log.Extentions;
using d.Log.Interfaces;
using Microsoft.SharePoint.Administration;

namespace d.Log.Loggers
{
    public class SPLogger:ILog
    {
        public string ApplicationName { get; set; }

        public SPLogger()
        {
            ApplicationName = "ILog.SPLogger";
        }
        
        public void Error(Exception ex)
        {
            Log(EventLogEntryType.Error, ApplicationName, ex.ToStringEx());
        }

        public void Error(string message, Exception ex)
        {
            Log(EventLogEntryType.Error, message, ex.ToStringEx());
        }

        public void Log(System.Diagnostics.EventLogEntryType entry, string category, string logMessage)
        {
            var traceSeverity = TraceSeverity.Unexpected;
            var evtSeverity = EventSeverity.Error;

            switch (entry)
            {
                case EventLogEntryType.Information:
                case EventLogEntryType.FailureAudit:
                case EventLogEntryType.SuccessAudit:
                    traceSeverity = TraceSeverity.Verbose;
                    evtSeverity = EventSeverity.Information;
                    break;
                case EventLogEntryType.Warning:
                    traceSeverity = TraceSeverity.Medium;
                    evtSeverity = EventSeverity.Warning;
                    break;
                default:
                    traceSeverity = TraceSeverity.Unexpected;
                    evtSeverity = EventSeverity.Error;
                    break;
            }

            try
            {

                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory(category, traceSeverity, evtSeverity), traceSeverity, logMessage, null);

            }
            catch (Exception)
            {
                // throw                
            }
        }
        
        public void Info(string logMessage)
        {
            Log(EventLogEntryType.Information, ApplicationName, logMessage);
        }

      
    }
}
