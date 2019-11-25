using DefineAnInterfaceIPerson.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, Dictionary<int, IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public Dictionary<int, IPrivate> Privates { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var item in this.Privates)
            {
                sb.AppendLine("  " + item.Value.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
