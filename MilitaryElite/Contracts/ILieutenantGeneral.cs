using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public Dictionary<int,IPrivate> Privates { get; }
    }
}
