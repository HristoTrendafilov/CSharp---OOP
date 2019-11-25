using System;

namespace ExplicitInterfaces
{
    public class Program
    {
       public static void Main(string[] args)
        {
            while (true)
            {
                var info = Console.ReadLine().Split();
               
                if (info[0] == "End")
                {
                    break;
                }
               
                var name = info[0];
                var country = info[1];
                var age = int.Parse(info[2]);
                
                IResident resident = new Citizen(name, country, age);
                IPerson person = new Citizen(name, country, age);
                
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
