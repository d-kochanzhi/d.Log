using d.Log.Interfaces;
using System;
using System.Diagnostics;
using d.Log.Extentions;

namespace d.Log.Loggers
{
    public class ConsoleLogger : ILog
    {
        public string ApplicationName { get; set; }
        public ConsoleColor TextErrorColor { get; set; }
        public ConsoleColor TextInfoColor { get; set; }

        public ConsoleLogger()
        {
            ApplicationName = "ILog.ConsoleLogger";
        }

        public void Error(Exception ex)
        {
            WriteColoredText(ex.ToStringEx(), TextErrorColor);
        }

        public void Error(string message, Exception ex)
        {
            WriteColoredText(string.Concat(message, Environment.NewLine, ex.ToStringEx()), TextErrorColor);
        }

        public void Info(string logMessage)
        {
            WriteColoredText(logMessage, TextInfoColor);
        }
        
        public void Log(System.Diagnostics.EventLogEntryType entry, string moduleName, string logMessage)
        {
            switch (entry)
            {
                case EventLogEntryType.Error:
                    WriteColoredText(string.Concat(moduleName, Environment.NewLine, logMessage), TextErrorColor);
                    break;

                default:
                    WriteColoredText(string.Concat(moduleName, Environment.NewLine, logMessage), TextInfoColor);
                    break;
            }
        }

        private void WriteColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(string.Concat(ApplicationName, Environment.NewLine, text));
            Console.ResetColor();
        }

      
    }
}
