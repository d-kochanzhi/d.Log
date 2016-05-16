using System;
using System.Diagnostics;
using System.Reflection;

namespace d.Log.Interfaces
{
    public interface ILog
    {
        string ApplicationName { get; set; }

        void Error(Exception ex);
        void Error(string message, Exception ex);

        void Info(string message);
      

        void Log(EventLogEntryType entry, string category, string message);
    }
}