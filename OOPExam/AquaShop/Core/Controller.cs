using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
                default:
                    throw new InvalidOperationException("Invalid aquarium type.");
            }

            this.aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            
            switch (decorationType)
            {
                case "Ornament":
                    decoration = new Ornament();
                    break;
                case "Plant":
                    decoration = new Plant();
                    break;
                default:
                    throw new InvalidOperationException("Invalid decoration type.");
            }

            this.decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquariumToCheck = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if(fishType!= "FreshwaterFish" && fishType!= "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            if(aquariumToCheck is FreshwaterAquarium && fishType == "FreshwaterFish")
            {
                var fish = new FreshwaterFish(fishName, fishSpecies, price);
                aquariumToCheck.AddFish(fish);
            }
            else if(aquariumToCheck is SaltwaterAquarium && fishType == "SaltwaterFish")
            {
                var fish = new SaltwaterFish(fishName, fishSpecies, price);
                aquariumToCheck.AddFish(fish);
            }
            else
            {
                return "Water not suitable.";
            }

            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal value = 0;

            foreach (var fish in aquarium.Fish)
            {
                value += fish.Price;
            }
            foreach (var decoration in aquarium.Decorations)
            {
                value += decoration.Price;
            }

            return $"The value of Aquarium {aquariumName} is {value:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            var count = aquarium.Fish.Count;

            return $"Fish fed: {count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.Models.FirstOrDefault(x => x.GetType().Name == decorationType);

            if(decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            else
            {
                this.aquariums.FirstOrDefault(x => x.Name == aquariumName).AddDecoration(decoration);
                this.decorations.Remove(decoration);
            }

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
          
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
