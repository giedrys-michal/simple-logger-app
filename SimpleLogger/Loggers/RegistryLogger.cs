using Microsoft.Win32;
using SimpleLogger.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Loggers
{
    class RegistryLogger : BaseLogger
    {
        public override void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_hh:mm:ss");

            Console.WriteLine("\n > {0}\tRegistry logger started...", timestamp);

            lock (threadLocker)
            {
                try
                {
                    RegistryKey key;
                    key = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("SimpleLoggerLogs");
                    key.SetValue(timestamp, message);

                    Console.WriteLine(" > Registry key path: {0}", key.Name);

                    key.Close();

                    Console.WriteLine(" > Data logged: {0}", message);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(" > ...Registry logger failed, error message:\n{0}", e.Message);
                }
                catch (SecurityException e)
                {
                    Console.WriteLine(" > ...Registry logger failed, error message:\n{0}", e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(" > ...Registry logger failed, error message:\n{0}", e.Message);
                }
                finally
                {
                    Console.WriteLine(" > === LOGGER END ===\n");
                }
            }
        }
    }
}
