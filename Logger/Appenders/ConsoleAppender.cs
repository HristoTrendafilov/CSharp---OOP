using System;
using System.Collections.Generic;
using System.Text;
using LoggerUser.Enums;
using LoggerUser.Layouts;

namespace LoggerUser.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
        }

        public override void Append(string datetime,ReportLevel logLevel,string messege)
        {
            if (logLevel >= this.ReportLevel)
            {
                Console.WriteLine(this.Layout.Format,datetime,logLevel,messege);
            }
            this.Counter++;
        }
    }
}
