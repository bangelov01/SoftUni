using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.FootballTeamGenerator
{
    public static class Validator
    {
        public static void IfIsNullEmptyOrWhiteSpace(string value, string argument)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new Exception(argument);
            }
        }

        public static void IfInBetweenMinMaxValue(decimal value, string message, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new Exception(message);
            }
        }

        public static void IfTeamDoesentExist(Team team, string name)
        {
            if (team == null)
            {
                throw new Exception($"Team {name} does not exist.");
            }
        }
    }
}
