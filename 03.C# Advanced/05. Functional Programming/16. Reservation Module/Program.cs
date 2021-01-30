using System;
using System.Collections.Generic;
using System.Linq;

namespace _16._Reservation_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitedNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, Dictionary<string, List<string>>> filteredHolder = new Dictionary<string, Dictionary<string, List<string>>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commandArr = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = commandArr[0];
                string filterType = commandArr[1];
                string parameter = commandArr[2];

                Func<string, bool> predicate = GetPredicate(filterType, parameter);

                if (action == "Add filter")
                {
                    List<string> holder = new List<string>();
                    holder = invitedNames.Where(predicate).ToList();

                    if (!filteredHolder.ContainsKey(filterType))
                    {
                        filteredHolder.Add(filterType, new Dictionary<string, List<string>>());
                        filteredHolder[filterType].Add(parameter, holder);
                    }
                    else if (!filteredHolder[filterType].ContainsKey(parameter))
                    {
                        filteredHolder[filterType].Add(parameter, holder);
                    }
                    else
                    {
                        filteredHolder[filterType][parameter].AddRange(holder);
                    }
                }
                else if (action == "Remove filter")
                {
                    filteredHolder[filterType].Remove(parameter);
                }
            }

            foreach (var key in filteredHolder)
            {
                foreach (var param in filteredHolder[key.Key])
                {
                    foreach (var name in param.Value)
                    {
                        if (invitedNames.Contains(name))
                        {
                            invitedNames.Remove(name);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", invitedNames));
        }

        static Func<string, bool> GetPredicate(string filterType, string parameter)
        {
            if (filterType == "Starts with")
            {
                return name => name.StartsWith(parameter);
            }
            else if (filterType == "Ends with")
            {
                return name => name.EndsWith(parameter);
            }
            else if (filterType == "Length")
            {
                int length = int.Parse(parameter);
                return name => name.Length == length;
            }
            else
            {
                return name => name.Contains(parameter);
            }
        }
    }
}
