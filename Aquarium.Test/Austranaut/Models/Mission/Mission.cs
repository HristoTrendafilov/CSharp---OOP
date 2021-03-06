﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath)
                {
                    if (planet.Items.Count == 0)
                    {
                        break;
                    }
                    
                    var currentItem = planet.Items.FirstOrDefault();

                    if (currentItem != null)
                    {
                        astronaut.Breath();
                        astronaut.Bag.Items.Add(currentItem);
                        planet.Items.Remove(currentItem);
                    }
                }
            }
        }
    }
}
