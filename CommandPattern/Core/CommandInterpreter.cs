using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var commandArr = args
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);
            
            var commandName = (commandArr[0] + "Command").ToLower();
            var commandArgs = commandArr.Skip(1).ToArray();

            var commandType = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(n => n.Name.ToLower() == commandName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }
            
            var instanceType = Activator.CreateInstance(commandType) as ICommand;

            if (instanceType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            var result = instanceType.Execute(commandArgs);
            return result;
        }
    }
}
