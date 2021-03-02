using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Team> teams = new HashSet<Team>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    var info = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                    if (info[0] == "Team")
                    {
                        Team team = new Team(info[1]);
                        teams.Add(team);
                    }
                    else if (info[0] == "Add")
                    {
                        decimal endurance = decimal.Parse(info[3]);
                        decimal sprint = decimal.Parse(info[4]);
                        decimal dribble = decimal.Parse(info[5]);
                        decimal passing = decimal.Parse(info[6]);
                        decimal shooting = decimal.Parse(info[7]);

                        var team = teams.FirstOrDefault(x => x.Name == info[1]);

                        Validator.IfTeamDoesentExist(team, info[1]);

                        Player player = new Player(info[2], endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player);
                    }
                    else if (info[0] == "Remove")
                    {
                        var team = teams.First(x => x.Name == info[1]);


                        team.RemovePlayer(info[2]);
                    }
                    else if (info[0] == "Rating")
                    {
                        var team = teams.FirstOrDefault(x => x.Name == info[1]);

                        Validator.IfTeamDoesentExist(team, info[1]);

                        Console.WriteLine($"{team.Name} - {(int)team.GetRating()}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
