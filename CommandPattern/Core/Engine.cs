using CommandPattern.Core;
using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    internal class Engine : IEngine
    {
        private ICommandInterpreter command;

        public Engine(ICommandInterpreter command)
        {
            this.command = command;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();

                var result = command.Read(input);
                Console.WriteLine(result);
            }
        }
    }
}