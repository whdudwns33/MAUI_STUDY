using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogSample.Util;

namespace LogSample.Util
{
    class LogMessage
    {
        public string _message;
        public LogType _logType;

        public LogMessage(LogType logType, string message)
        {
            _logType = logType;
            _message = message;
        }
    }
}
