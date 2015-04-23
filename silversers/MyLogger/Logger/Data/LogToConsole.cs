using System;
using System.Threading;

namespace MyLogger
{
    class LogToConsole : IData
    {
        public void Log (MessageType severity, string message)
        {
            Thread.Sleep (1000); // Checking multithreading

            Console.WriteLine ("<{0} | {1}>  {2}", severity.ToString (), DateTime.Now.ToString (), message);
        }
    }
}