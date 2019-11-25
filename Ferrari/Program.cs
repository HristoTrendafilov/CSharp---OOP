using System;

namespace Ferrari
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var ferrari = new Ferrari(name);
            Console.WriteLine(ferrari);
        }
    }
}
