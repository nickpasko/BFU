using System;
using System.Threading;
using MyLogger;
namespace LoggerTest
{
    class Program
    {
        static void Main (string[] args)
        {
            Logger log1 = new Logger ();
            log1.Init (LogStorageType.Console, MessageType.Warning, LoggerMode.outEx);
            log1.Log (MessageType.Info, "Should not be displayed");
            log1.Log (MessageType.Warning, "Attention!");

            Logger log2 = new Logger ();
            log2.Init (LogStorageType.File, MessageType.Debug, LoggerMode.inEx);
            log2.Log (MessageType.Error, "Error!");
            log2.Log (MessageType.Error, "And another");
            
            for (int i = 1; i != 7; ++i)
            {
                Console.WriteLine ("{0}) The main thread", i);
                Thread.Sleep (400);
            }
        }
    }
}
