using _08.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get; }

        public void AddMission(IMission mission);
    }
}
