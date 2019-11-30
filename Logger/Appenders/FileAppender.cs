using System;
using System.Collections.Generic;
using System.Text;
using LoggerUser.Enums;
using LoggerUser.Layouts;
using LoggerUser.Loggers;

namespace LoggerUser.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout,ILogFile logFile)
            :base(layout)
        {
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public override void Append(string datetime, ReportLevel logLevel, string messege)
        {
            if (logLevel >= this.ReportLevel)
            {
                this.LogFile.Write(string.Format(this.Layout.Format, datetime, logLevel, messege));
            }
            this.Counter++;
        }
        public override string ToString()
        {
            return base.ToString() + $", File size: {this.LogFile.Size}";
        }
    }
}
