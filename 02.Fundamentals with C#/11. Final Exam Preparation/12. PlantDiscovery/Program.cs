using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _12._PlantDiscovery
{
    class Plant
    {
        public Plant(int rarity)
        {
            Rarity = rarity;
            Rating = new List<int>();

        }
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            while (numberOfLines > 0)
            {
                string[] plantArr = Console.ReadLine().Split("<->",StringSplitOptions.RemoveEmptyEntries);

                string plant = plantArr[0];
                int rarity = int.Parse(plantArr[1]);

                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, new Plant (rarity));
                    plants[plant].Rating.Add(0);
                }
                else
                {
                    plants[plant].Rarity = rarity;
                }

                numberOfLines--;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string regex = @"\s+";

                command = Regex.Replace(command, regex, "");

                string[] commandArr = command.Split(new char[] { ':', '-' },StringSplitOptions.RemoveEmptyEntries);

                string action = commandArr[0];
                string plantName = commandArr[1];

                if (action == "Rate")
                {
                    int rating = int.Parse(commandArr[2]);

                    if (plants.ContainsKey(plantName))
                    {
                        plants[plantName].Rating.Remove(0);
                        plants[plantName].Rating.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    
                }
                else if (action == "Update")
                {
                    int rarity = int.Parse(commandArr[2]);

                    if (plants.ContainsKey(plantName))
                    {
                        plants[plantName].Rarity = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "Reset")
                {
                    if (plants.ContainsKey(plantName))
                    {
                        plants[plantName].Rating = new List<int>() {0};
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in plants.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.Rating.Average()))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {item.Value.Rating.Average():f2}");
            }
        }
    }
}
