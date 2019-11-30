using LoggerUser.Appenders;
using LoggerUser.Enums;
using LoggerUser.Factories;
using LoggerUser.Layouts;
using LoggerUser.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerUser.Core
{
    public class Engine
    {
        public void Run()
        {
            var appenders = new List<IAppender>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var inputInfo = Console.ReadLine().Split();
                var appenderType = inputInfo[0];
                var layoutType = inputInfo[1];
                ReportLevel reportLevel = ReportLevel.Info;
                
                if (inputInfo.Length > 2)
                {
                     reportLevel = Enum.Parse<ReportLevel>(inputInfo[2], true);
                }

                ILayout layout = LayoutFactory.CreateLayout(layoutType);
                IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
                appenders.Add(appender);
            }

            var input = Console.ReadLine();

            ILogger logger = new Logger(appenders.ToArray());

            while (input!="END")
            {
                var inputInfo = input.Split("|");
                var loggerMethodType = inputInfo[0];
                var date = inputInfo[1];
                var messege = inputInfo[2];

                if (loggerMethodType == "INFO")
                {
                    logger.Info(date, messege);
                }
                else if (loggerMethodType == "WARNING")
                {
                    logger.Warning(date, messege);
                }
                else if (loggerMethodType == "ERROR")
                {
                    logger.Error(date, messege);
                }
                else if (loggerMethodType == "CRITICAL")
                {
                    logger.Critical(date, messege);
                }
                else if (loggerMethodType == "FATAL")
                {
                    logger.Fatal(date, messege);
                }
                input = Console.ReadLine();
            }
            
            Console.WriteLine("Logger info");
            
            foreach (var item in appenders)
            {
                Console.WriteLine(item);
            }
        }
    }
}
