using _08.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs { get => this.repairs.AsReadOnly(); }

        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var repair in repairs)
            {
                sb.AppendLine($"  {repair}");
            }

            return sb.ToString().Trim();
        }
    }
}
