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
}
