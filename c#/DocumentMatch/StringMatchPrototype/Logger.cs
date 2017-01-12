using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace StringMatchPrototype
{
    public enum LogType
    {
        LOG_INFO = 0,
        LOG_ERROR,
        LOG_DEBUG
    }

    public class Logger
    {
        public static string FileName = "DocMatch.log";
        public static void writeLog(string message, LogType logType)
        {
            using (StreamWriter w = File.AppendText(FileName))
            {
                switch (logType)
                {
                    case LogType.LOG_INFO:
                        w.WriteLine("--- LOG INFO --- {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                        w.WriteLine("  :{0}", message);
                        w.WriteLine("-------------------------------");
                        w.Flush();
                        break;

                    case LogType.LOG_ERROR:
                        w.WriteLine("--- LOG ERROR --- {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                        w.WriteLine("  :{0}", message);
                        w.WriteLine("-------------------------------");
                        w.Flush();
                        break;
                }
                // Close the writer and underlying file.
                w.Close();
            }
        }
    }
}
