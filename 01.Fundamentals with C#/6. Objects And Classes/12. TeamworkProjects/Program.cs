using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _12._TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] createTeam = Console.ReadLine().Split("-");

                string creator = createTeam[0];
                string teamName = createTeam[1];

                if ((!teams.Exists(x => x.TeamName == teamName)) && (!teams.Exists(x => x.Creator == creator)))
                {
                    Team newTeam = new Team(creator, teamName);
                    teams.Add(newTeam);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
                else if (teams.Exists(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");

                }
                else if (teams.Exists(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
            }

            string joinRequest = string.Empty;

            while ((joinRequest = Console.ReadLine()) != "end of assignment")
            {
                string[] joinRequestArr = joinRequest.Split("->");

                string user = joinRequestArr[0];
                string team = joinRequestArr[1];

                if (teams.Exists(x => x.TeamName == team) && (!teams.Exists(x => x.Members.Contains(user))) && (!teams.Exists(x => x.Creator.Contains(user))))
                {
                   int index = teams.FindIndex(x => x.TeamName == team);
                   teams[index].Members.Add(user);
                }
                else if (!teams.Exists(x => x.TeamName == team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (teams.Exists(x => x.Members.Contains(user)) || teams.Exists(x => x.Creator.Contains(user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                }
            }

            Team[] disbanded = teams.OrderBy(x => x.TeamName)
                                    .Where(x => x.Members.Count == 0)
                                    .ToArray();

            Team[] fullTeams = teams.OrderByDescending(x => x.Members.Count)
                                    .ThenBy(x => x.TeamName)
                                    .Where(x => x.Members.Count > 0)
                                    .ToArray();

            foreach (Team team in fullTeams)
            {
                Console.WriteLine(team);
            }
            Console.WriteLine("Teams to disband:");

            foreach (Team team in disbanded)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
}
