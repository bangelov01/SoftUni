using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09._NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine().Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(x => x)
                .ToArray();

            List<Demon> demonsInfo = new List<Demon>();

            string baseDmgReg = @"([-]?[\d]+\.?[\d]*)";

            for (int i = 0; i < demons.Length; i++)
            {

                string filter = "0123456789*/+-.";

                double health = demons[i].Where(x => !filter.Contains(x)).Sum(x => x);

                MatchCollection damageMatch = Regex.Matches(demons[i], baseDmgReg);

                double damage = 0;

                foreach (Match number in damageMatch)
                {
                    damage += double.Parse(number.ToString());
                }

                foreach (char letter in demons[i])
                {
                    if (letter == '*')
                    {
                        damage *= 2;
                    }
                    else if (letter == '/')
                    {
                        damage /= 2;
                    }
                }

                Demon addDem = new Demon(demons[i], health, damage);

                demonsInfo.Add(addDem);
            }


            foreach (var item in demonsInfo)
            {
                Console.WriteLine(item.ToString().TrimStart());
            }
        }
    }
}
