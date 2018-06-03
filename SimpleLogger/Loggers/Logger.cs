using SimpleLogger.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Loggers
{
    public static class Logger
    {
        private static BaseLogger _bl = null;
        public static void Log(string message, LogType type)
        {
            switch (type)
            {
                case LogType.File:
                    _bl = new FileLogger();
                    _bl.Log(message);
                    break;
                case LogType.Registry:
                    _bl = new RegistryLogger();
                    _bl.Log(message);
                    break;
                case LogType.EventLog:
                    _bl = new EventLogLogger();
                    _bl.Log(message);
                    break;
                default:
                    return;
            }
        }
    }
}
