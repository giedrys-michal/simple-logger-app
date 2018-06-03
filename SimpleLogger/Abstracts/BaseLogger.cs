using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Abstracts
{
    public abstract class BaseLogger : ILogger
    {
        protected readonly object threadLocker = new object();
        public abstract void Log(string message);
    }
}
