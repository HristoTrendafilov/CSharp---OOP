using DefineAnInterfaceIPerson.Contracts;
using DefineAnInterfaceIPerson.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; }
    }
}
