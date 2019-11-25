using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public ICollection<IRepair> Repairs { get;}
    }
}
