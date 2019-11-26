using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.Name = name;
            this.Weight = weight;
            this.WingSize = wingSize;
        }
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
