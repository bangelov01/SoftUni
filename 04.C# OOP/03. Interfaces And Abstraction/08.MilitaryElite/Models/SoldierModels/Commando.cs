using _08.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions { get => this.missions.AsReadOnly(); }

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var mission in missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().Trim();
        }
    }
}
