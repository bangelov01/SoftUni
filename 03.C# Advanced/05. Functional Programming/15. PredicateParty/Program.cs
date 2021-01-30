using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleComing = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandArr[0];
                string rule = commandArr[1];
                string toAdjust = commandArr[2];

                Predicate<string> executeCommand = GetPredicate(rule, toAdjust);

                if (action == "Remove")
                {
                    peopleComing.RemoveAll(executeCommand);
                }
                else if (action == "Double")
                {
                    List<string> holder = new List<string>();
                    holder = peopleComing.FindAll(executeCommand);
                    foreach (var perosn in holder)
                    {
                        int index = peopleComing.IndexOf(perosn);
                        peopleComing.Insert(index, perosn);
                    }
                }
            }
            if (peopleComing.Count > 0)
            {
                Console.WriteLine($"{ string.Join(", ", peopleComing.ToList())} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        public static Predicate<string> GetPredicate(string rule, string toAdjust)
        {
            if (rule == "StartsWith")
            {
                return n => n.StartsWith(toAdjust);
            }
            else if (rule == "EndsWith")
            {
                return n => n.EndsWith(toAdjust);
            }
            else
            {
                int length = int.Parse(toAdjust);
                return n => n.Length == length;
            }
        }

    }
}
