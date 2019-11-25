using DefineAnInterfaceIPerson.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
