using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private readonly IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            this.bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                
                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
               
                oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag => this.bag;

        public virtual void Breath()
        {
            if (this.Oxygen - 10 >= 0)
            {
                this.Oxygen -= 10;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
