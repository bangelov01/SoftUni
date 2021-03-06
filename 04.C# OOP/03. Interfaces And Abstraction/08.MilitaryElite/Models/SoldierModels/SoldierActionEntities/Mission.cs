using _08.MilitaryElite.Contracts;
using _08.MilitaryElite.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {this.State}";
        }
    }
}
