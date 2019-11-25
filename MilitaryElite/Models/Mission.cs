using DefineAnInterfaceIPerson.Contracts;
using DefineAnInterfaceIPerson.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
