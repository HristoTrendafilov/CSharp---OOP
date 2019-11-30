using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerUser.Loggers
{
    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";
        public int Size
         => File.ReadAllText(LogFilePath)
            .Replace(" ","")
            .Where(char.IsLetter)
            .Sum(x => x);

        public void Write(string messege)
        {
            File.AppendAllText(LogFilePath, messege + Environment.NewLine);
        }
    }
}
