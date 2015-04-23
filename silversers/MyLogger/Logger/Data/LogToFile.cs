using System;
using System.IO;
using System.Configuration;
using System.Threading;

namespace MyLogger
{
    class LogToFile : IData
    {
        private LoggerMode modOfException;

        private AppSettingsReader readAppConfig;
        private string path;

        private FileStream file1;
        private StreamWriter writer;

         
        public LogToFile (LoggerMode mode)
        {
            modOfException = mode;
            readAppConfig = new AppSettingsReader ();

            path = (string)readAppConfig.GetValue ("Path", typeof (string));
        }

        public void Log (MessageType severity, string message)
        {
            Thread.Sleep (1000); // Checking multithreading
            try
            {
                file1 = new FileStream (path, FileMode.Append);
                writer = new StreamWriter (file1);
                writer.WriteLine (String.Format ("<{0} | {1}>  {2}", severity.ToString (), DateTime.Now.ToString (), message));
                writer.Close ();
            }
            catch (Exception ex)
            {
                if (modOfException == LoggerMode.outEx)
                    throw ex;
                else
                    Console.WriteLine ("Inner exception handling...");
            }
        }
    }
}
