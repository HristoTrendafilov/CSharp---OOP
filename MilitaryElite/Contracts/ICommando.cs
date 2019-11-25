using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public ICollection<IMission> Missions { get; }
    }
}
