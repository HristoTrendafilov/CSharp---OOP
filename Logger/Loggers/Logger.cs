using System;
using System.Collections.Generic;
using System.Text;
using LoggerUser.Appenders;
using LoggerUser.Enums;

namespace LoggerUser.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }

        public IAppender[] Appenders 
        {
            get { return this.appenders; } 
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Appenders),"value cannot be null");
                }
                this.appenders = value;
            }
        }

        public void Critical(string datetime, string messege)
        {
            Append(datetime, ReportLevel.Critical, messege);
        }

        public void Error(string datetime, string messege)
        {
            Append(datetime, ReportLevel.Error, messege);
        }

        public void Fatal(string datetime, string messege)
        {
            Append(datetime, ReportLevel.Fatal, messege);
        }
        public void Warning(string datetime, string messege)
        {
            Append(datetime, ReportLevel.Warning, messege);
        }

        public void Info(string datetime, string messege)
        {
            Append(datetime, ReportLevel.Info, messege);
        }
        private void Append(string datetime, ReportLevel error, string messege)
        {
            for (int i = 0; i < this.Appenders.Length; i++)
            {
                Appenders[i].Append(datetime, error, messege);
            }
        }
    }
}
