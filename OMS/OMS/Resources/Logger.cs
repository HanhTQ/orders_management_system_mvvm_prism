using OMS.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Resources
{
    public class Logger : ILogger
    {
        private string _logsFilePath;

        public Logger()
        {
            string local = AppDomain.CurrentDomain.BaseDirectory;
            _logsFilePath = local + Defines.FILENAME_LOGS;
            if (!File.Exists(_logsFilePath))
            {
                File.Create(_logsFilePath);
            }
        }

        public void LogIn4(string fName, string msg)
        {
            try
            {
                using (var streamWriter = new StreamWriter(_logsFilePath, true, Encoding.UTF8))
                {
                    streamWriter.Write("\r\nIn4 Log Entry => ");
                    streamWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                    streamWriter.WriteLine("Function: {0}", fName);
                    streamWriter.WriteLine("");
                    streamWriter.WriteLine($"{msg}");
                    streamWriter.WriteLine("-------------------------------");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception in function LogIn4 in class Logger: " + e.Message);
                Console.WriteLine(msg);
            }
        }

        public void LogErr(string fName, string msg)
        {
            try
            {
                using (var streamWriter = new StreamWriter(_logsFilePath, true, Encoding.UTF8))
                {
                    streamWriter.Write("\r\nError Log Entry => ");
                    streamWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                    streamWriter.WriteLine("Function: {0}", fName);
                    streamWriter.WriteLine("");
                    streamWriter.WriteLine($"{msg}");
                    streamWriter.WriteLine("-------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in function LogErr in class Logger: " + e.Message);
                Console.WriteLine(msg);
            }
        }
    }
}
