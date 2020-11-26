using System;
using System.Collections.Generic;
using System.Text;

namespace _12._TeamworkProjects
{
    class Team
    {
        public Team(string creator, string teamName)
        {
            Creator = creator;
            TeamName = teamName;
            Members = new List<string>();

        }
        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }

        public override string ToString()
        {
            StringBuilder stringb = new StringBuilder();

            stringb.AppendLine($"{TeamName}");
            stringb.AppendLine($"- {Creator}");

            foreach (var member in Members)
            {
                stringb.AppendLine($"-- {member}");
            }

            return stringb.ToString().TrimEnd();
        }
    }
}
