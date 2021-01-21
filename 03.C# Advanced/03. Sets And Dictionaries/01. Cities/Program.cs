using System;
using System.Collections.Generic;

namespace _01._Cities
{
    class Program
    {
        static void Main(string[] args)
        {
            int cityNumber = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> infoDict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < cityNumber; i++)
            {
                string[] info = Console.ReadLine().Split();
                string continent = info[0];
                string country = info[1];
                string city = info[2];

                if (!infoDict.ContainsKey(continent))
                {
                    infoDict.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!infoDict[continent].ContainsKey(country))
                {
                    infoDict[continent].Add(country, new List<string>());
                }
                infoDict[continent][country].Add(city);
            }

            foreach (var continent in infoDict)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}
