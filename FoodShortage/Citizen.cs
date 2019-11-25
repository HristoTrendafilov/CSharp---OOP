using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : Iperson, IBuyer
    {
        private int food=0;

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }

        public int Food { get => food; set => food = value; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
