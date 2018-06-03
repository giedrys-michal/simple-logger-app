using SimpleLogger.Abstracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Loggers
{
    class EventLogLogger : BaseLogger
    {
        public override void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_hh:mm:ss");
            int eventID = 1;

            Console.WriteLine("\n > {0}\tEventLog logger started...", timestamp);

            lock (threadLocker)
            {
                try
                {
                    EventLog eventLog = new EventLog();

                    if (!EventLog.SourceExists("SimpleLogger"))
                    {
                        EventLog.CreateEventSource("SimpleLogger", "Application");
                    }

                    eventLog.Source = "SimpleLogger";
                    eventLog.WriteEntry(message, EventLogEntryType.Information, eventID);

                    Console.WriteLine(" > EventLog data location: Application\\{0}", eventLog.Source);
                    Console.WriteLine(" > Data logged: {0}", message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(" > ...EventLog logger failed, error message:\n{0}", e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(" > ...EventLog logger failed, error message:\n{0}", e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(" > ...EventLog logger failed, error message:\n{0}", e.Message);
                }
                finally
                {
                    Console.WriteLine(" > === LOGGER END ===\n");
                }
            }
        }
    }
}
