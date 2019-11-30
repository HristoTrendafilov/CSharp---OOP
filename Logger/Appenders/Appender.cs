using System;
using System.Collections.Generic;
using System.Text;
using LoggerUser.Enums;
using LoggerUser.Layouts;

namespace LoggerUser.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }
        protected int Counter { get; set; }

        public abstract void Append(string datetime, ReportLevel logLevel, string messege);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.Counter}";
        }
    }
}
