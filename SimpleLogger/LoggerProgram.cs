using SimpleLogger.Abstracts;
using SimpleLogger.Loggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    public enum LogType { File, Registry, EventLog }

    class LoggerProgram
    {
        static void Main(string[] args)
        {
            string message = String.Empty;

            Console.WriteLine("\nPrzyklad programu logujacego komunikaty do\n\tpliku tekstowego\n\trejestru systemu\n\tdziennika zdarzen\n");
            Console.Write("Wprowadz wiadomosc ktora chcesz zalogowac i nacisnij \"ENTER\"\n\n > ");
     
            message = Console.ReadLine();
            
            foreach (LogType type in Enum.GetValues(typeof(LogType)))
            {
                Logger.Log(message, type);
            }

            Console.ReadKey();
        }
    }


    //public class FileLogger : BaseLogger
    //{
    //public string logFilePath = @"C:\simpleLoggerLog.txt";

    //public override void Log(string message)
    //{
    //    string timestamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
    //    message = String.Join(" -> ", timestamp, message);

    //    Console.WriteLine("\n > {0}\tFile logger started...", timestamp);
    //    Console.WriteLine(" > Log file path: {0}", logFilePath);

    //    lock (threadLocker)
    //    {
    //        try
    //        {
    //            if (!File.Exists(logFilePath))
    //            {
    //                FileStream fs = File.Create(logFilePath);
    //                fs.Close();
    //            }

    //            StreamWriter sw = new StreamWriter(logFilePath);
    //            sw.WriteLine(message);
    //            sw.Close();

    //            Console.WriteLine(" > Data logged: {0}", message);
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(" > ...File logger failed, error message:\n{0}", e.Message);
    //        }
    //        finally
    //        {
    //            Console.WriteLine(" > === LOGGER END ===\n");
    //        }
    //    }
    //}
    //}

    //public class RegistryLogger : BaseLogger
    //{
    //    public override void Log(string message)
    //    {
    //        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_hh:mm:ss");

    //        Console.WriteLine("\n > {0}\tRegistry logger started...", timestamp);

    //        lock (threadLocker)
    //        {
    //            try
    //            {
    //                Microsoft.Win32.RegistryKey key;
    //                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("SimpleLoggerLogs");
    //                key.SetValue(timestamp, message);
                    
    //                Console.WriteLine(" > Registry key path: {0}", key.Name);

    //                key.Close();

    //                Console.WriteLine(" > Data logged: {0}", message);
    //            }
    //            catch (Exception e)
    //            {
    //                Console.WriteLine(" > ...Registry logger failed, error message:\n{0}", e.Message);
    //            }
    //            finally
    //            {
    //                Console.WriteLine(" > === LOGGER END ===\n");
    //            }
    //        }
    //    }
    //}

    //public class EventLogLogger : BaseLogger
    //{
    //    public override void Log(string message)
    //    {
    //        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_hh:mm:ss");
    //        int eventID = 1;

    //        Console.WriteLine("\n > {0}\tEventLog logger started...", timestamp);

    //        lock (threadLocker)
    //        {
    //            try
    //            {
    //                EventLog eventLog = new EventLog();

    //                if (!EventLog.SourceExists("SimpleLogger"))
    //                {
    //                    EventLog.CreateEventSource("SimpleLogger", "Application");
    //                }

    //                eventLog.Source = "SimpleLogger";
    //                eventLog.WriteEntry(message, EventLogEntryType.Information, eventID);

    //                Console.WriteLine(" > EventLog data location: Application\\{0}", eventLog.Source );
    //                Console.WriteLine(" > Data logged: {0}", message);
    //            }
    //            catch (Exception e)
    //            {
    //                Console.WriteLine(" > ...EventLog logger failed, error message:\n{0}", e.Message);
    //            }
    //            finally
    //            {
    //                Console.WriteLine(" > === LOGGER END ===\n");
    //            }
    //        }
    //    }
    //}

    //public static class Logger
    //{
    //    private static BaseLogger _bl = null;
    //    public static void Log(string message, LogType type)
    //    {
    //        switch (type)
    //        {
    //            case LogType.File:
    //                _bl = new FileLogger();
    //                _bl.Log(message);
    //                break;
    //            case LogType.Registry:
    //                _bl = new RegistryLogger();
    //                _bl.Log(message);
    //                break;
    //            case LogType.EventLog:
    //                _bl = new EventLogLogger();
    //                _bl.Log(message);
    //                break;
    //            default:
    //                return;
    //        }
    //    }
    //}
}
