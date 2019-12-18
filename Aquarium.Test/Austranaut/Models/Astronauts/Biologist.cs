using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double biologistInitialUnitsOfOxigen = 70;
        public Biologist(string name) 
            : base(name, biologistInitialUnitsOfOxigen)
        {
        }
        public override void Breath()
        {
            if (this.Oxygen - 5 >= 0)
            {
                this.Oxygen -= 5;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
