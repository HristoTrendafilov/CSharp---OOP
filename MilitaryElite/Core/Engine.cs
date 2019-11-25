using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            var input = Console.ReadLine();
            
            
            while (input != "End")
            {
                try
                {
                    var inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string result = commandInterpreter.Read(inputInfo);
                    Console.WriteLine(result);

                }
                catch (Exception)
                {

                }
                input = Console.ReadLine();
            }
        }
    }
}
