using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Mission;

namespace SpaceStation.Core
{
    class Controller : IController
    {
        private readonly AstronautRepository astronautRepository;
        private readonly PlanetRepository planetRepository;
        private Mission mission;
        private int exploredPlanets;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
            this.exploredPlanets = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;
            
            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautType));
            }

            astronautRepository.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            
            planetRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            if (!astronautRepository.Models.Any(x => x.Oxygen > 60))
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            var astronautsToGo = this.astronautRepository.Models.Where(x => x.Oxygen > 60).ToList();
            var planet = planetRepository.FindByName(planetName);

            mission.Explore(planet, astronautsToGo);
            
            var deadAstronauts = astronautsToGo.Where(x => !x.CanBreath).ToList().Count();
            exploredPlanets++;

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            
            foreach (var astronaut in astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine("Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ",astronaut.Bag.Items)}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (!astronautRepository.Models.Any(x => x.Name == astronautName))
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            else
            {
                var astronaut = astronautRepository.Models.FirstOrDefault(x => x.Name == astronautName);
                astronautRepository.Remove(astronaut);
            }

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
