using SimpleLogger.Abstracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Loggers
{
    class FileLogger : BaseLogger
    {
        public string logFilePath = String.Concat(Directory.GetCurrentDirectory(), "\\simpleLoggerLog.txt");

        public override void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            message = String.Join(" -> ", timestamp, message);

            Console.WriteLine("\n > {0}\tFile logger started...", timestamp);
            Console.WriteLine(" > Log file path: {0}", logFilePath);

            lock (threadLocker)
            {
                try
                {
                    if (!File.Exists(logFilePath))
                    {
                        FileStream fs = File.Create(logFilePath);
                        fs.Close();
                    }

                    StreamWriter sw = new StreamWriter(logFilePath);
                    sw.WriteLine(message);
                    sw.Close();

                    Console.WriteLine(" > Data logged: {0}", message);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(" > ...File logger failed, error message:\n{0}", e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(" > ...File logger failed, error message:\n{0}", e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(" > ...File logger failed, error message:\n{0}", e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(" > ...File logger failed, error message:\n{0}", e.Message);
                }
                finally
                {
                    Console.WriteLine(" > === LOGGER END ===\n");
                }
            }
        }
    }
}
