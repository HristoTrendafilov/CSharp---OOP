using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FoodShortage
{
   public class Engine
    {
        private List<Iperson> people;

        public Engine()
        {
            this.people = new List<Iperson>();
        }

        public void Run()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                var command = Console.ReadLine().Split();

                if (command.Length == 4)
                {
                    var name = command[0];
                    var age = int.Parse(command[1]);
                    var id = command[2];
                    var birthdate = command[3];

                    var currCitizen = new Citizen(name, age, id, birthdate);
                    people.Add(currCitizen);
                }
                else if (command.Length == 3)
                {
                    var name = command[0];
                    var age = int.Parse(command[1]);
                    var group = command[2];
                    var currRebel = new Rebel(name, age, group);
                    people.Add(currRebel);
                }
            }
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                else
                {
                    if (people.Any(x => x.Name == command))
                    {
                        var person = people.FirstOrDefault(x => x.Name == command);
                        person.BuyFood();
                    }
                }
            }
            Console.WriteLine(people.Sum(x=>x.Food));
        }
    }
}
