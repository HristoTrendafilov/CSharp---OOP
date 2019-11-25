using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Contracts
{
    public interface IRepair
    {
        public string PartName { get; }
        public int HoursWorked { get; }
    }
}
