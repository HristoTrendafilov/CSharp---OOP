using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Engine
    {
        private List<IPet> citizens;

        public Engine()
        {
            this.citizens = new List<IPet>();
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
                else if (command[0]== "Citizen")
                {
                    var name = command[1];
                    var age = int.Parse(command[2]);
                    var id = command[3];
                    var birthday = command[4];
                    
                    var currCitizen = new Citizen(name, age, id,birthday);
                    citizens.Add(currCitizen);
                }
                else if (command[0]=="Robot")
                {
                    var model = command[1];
                    var id = command[2];
                    
                    var currRobot = new Robot(model, id);
                }
                else if (command[0] == "Pet")
                {
                    var name = command[1];
                    var birthdate = command[2];
                    
                    var currPet = new Pet(name, birthdate);
                    citizens.Add(currPet);
                }
            }
            var yearToPrint = Console.ReadLine();
            var sb = new StringBuilder();

            foreach (var citizen in citizens)
            {
                if (citizen.Birthdate.EndsWith(yearToPrint))
                {
                    sb.AppendLine(citizen.Birthdate);
                }
            }
            if (sb.Length > 0)
            {
                Console.WriteLine(sb.ToString().TrimEnd());
            }
       }
    }
}
