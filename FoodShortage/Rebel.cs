using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : Iperson, IBuyer
    {
        private int food=0;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; }

        public int Age { get; }
        public string Group { get; }

        public int Food { get => food; set => food = value; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
