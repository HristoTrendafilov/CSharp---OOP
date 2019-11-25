using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        private const string ferrariName = "488-Spider";

        public Ferrari(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public string UseGas()
        {
            return "Gas!";
        }
        public override string ToString()
        {
            return $"{ferrariName}/{UseBrakes()}/{UseGas()}/{this.Name}";
        }
    }
}
