using System;

namespace MyLogger
{
    interface IData
    {
        void Log (MessageType severity, String message);
    }
}
