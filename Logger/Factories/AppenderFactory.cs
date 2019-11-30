using LoggerUser.Appenders;
using LoggerUser.Enums;
using LoggerUser.Layouts;
using LoggerUser.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerUser.Factories
{
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            var layoutType = type.ToLower();
            switch (layoutType)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout) { ReportLevel = reportLevel};
                case "fileappender":
                    return new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel};
                default:
                    throw new ArgumentException("Invalid Appender Type");
            }
        }
    }
}
