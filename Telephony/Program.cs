using System;
using System.Linq;
namespace Telephony
{
   public class Program
    {
       public static void Main(string[] args)
       {
            var phoneNumbers = Console.ReadLine().Split().ToList();
            var sites = Console.ReadLine().Split().ToList();

            var smartphone = new Smartphone(phoneNumbers,sites);
            Console.WriteLine(smartphone.GetNumbers());
            Console.WriteLine(smartphone.GetSites());
       }
    }
}
