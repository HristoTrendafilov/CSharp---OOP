using LoggerUser.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerUser.Loggers
{
    public interface ILogger
    {
        IAppender[] Appenders { get; }
        void Error(string datetime,string messege);
        void Info(string datetime,string messege);
        void Fatal(string datetime,string messege);
        void Critical(string datetime,string messege);
        void Warning(string datetime,string messege);
    }
}
