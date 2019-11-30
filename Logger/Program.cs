using LoggerUser.Appenders;
using LoggerUser.Core;
using LoggerUser.Enums;
using LoggerUser.Layouts;
using LoggerUser.Loggers;
using System;

namespace LoggerUser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
