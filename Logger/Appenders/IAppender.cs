using LoggerUser.Enums;
using LoggerUser.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerUser.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }
        void Append(string datetime, ReportLevel logLevel, string messege);
    }
}
