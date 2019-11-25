using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Core
{
    public interface ICommandInterpreter
    {
        public string Read(string[] args);
    }
}
