using System;

namespace MyLogger
{
    public enum MessageType : byte { Debug, Info, Warning, Error };
    public enum LoggerMode : byte {outEx, inEx};
    public enum LogStorageType : byte {Console, File};

    public class Logger
    {
        
        private IData logWriter = null;
        private MessageType MinMsgLevel;
        private delegate void forAsunc (MessageType severity, String message);
        private forAsunc asuncLog;

        public void Init (LogStorageType destination, MessageType severityThreshold, LoggerMode mode)
        {
            MinMsgLevel = severityThreshold;
            switch (destination)
            {
                case LogStorageType.Console:
                    logWriter = new LogToConsole ();
                    break;

                case LogStorageType.File:
                    logWriter = new LogToFile (mode);
                    break;
            }
            asuncLog = new forAsunc (logWriter.Log);
        }

        public void Log(MessageType severity, String message)
        {
            if (severity >= MinMsgLevel)
                asuncLog.BeginInvoke (severity, message, null, null);
        }
    }
}
