using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astronauts;
        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models
            => this.astronauts.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.astronauts.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.astronauts.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return this.astronauts.Remove(model);
        }
    }
}
