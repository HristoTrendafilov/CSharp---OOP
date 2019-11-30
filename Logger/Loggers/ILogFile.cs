using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerUser.Loggers
{
    public interface ILogFile
    {
        void Write(string messege);
         int Size { get; }
    }
}
