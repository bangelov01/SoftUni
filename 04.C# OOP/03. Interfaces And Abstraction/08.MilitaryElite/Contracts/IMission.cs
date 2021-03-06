using _08.MilitaryElite.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }
        public State State { get; }
        public void CompleteMission();
    }
}
