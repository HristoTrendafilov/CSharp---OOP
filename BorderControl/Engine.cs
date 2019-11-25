using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BorderControl
{
    public class Engine
    {
        private List<IRobot> citizens;

        public Engine()
        {
            this.citizens = new List<IRobot>();
        }

        public void Run()
       {
            while (true)
            {
                var command = Console.ReadLine().Split();
                
                if (command[0] == "End")
                {
                    break;
                }
                else if (command.Length == 3)
                {
                    var name = command[0];
                    var age = int.Parse(command[1]);
                    var id = command[2];
                    
                    var currCitizen = new Citizen(name, age, id);
                    citizens.Add(currCitizen);
                }
                else if (command.Length == 2)
                {
                    var model = command[0];
                    var id = command[1];
                    
                    var currRobot = new Robot(model, id);
                    citizens.Add(currRobot);
                }
            }
            var fakeId = Console.ReadLine();
            var sb = new StringBuilder();

            for (int i = 0; i < citizens.Count; i++)
            {
                string currId = citizens[i].Id;
                if (currId.EndsWith(fakeId))
                {
                    sb.AppendLine(currId);
                }
            }

            if (sb.Length > 0)
            {
                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
