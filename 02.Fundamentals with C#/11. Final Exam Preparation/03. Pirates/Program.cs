using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            string cities = string.Empty;

            Dictionary<string, CityInfo> cityInfoDic = new Dictionary<string, CityInfo>(); 

            while ((cities = Console.ReadLine()) != "Sail")
            {
                string[] citiesArr = cities.Split("||", StringSplitOptions.RemoveEmptyEntries);

                string cityName = citiesArr[0];
                int population = int.Parse(citiesArr[1]);
                int gold = int.Parse(citiesArr[2]);

                if (!cityInfoDic.ContainsKey(cityName))
                {
                    cityInfoDic.Add(cityName, new CityInfo(population, gold));
                }
                else
                {
                    cityInfoDic[cityName].Population += population;
                    cityInfoDic[cityName].Gold += gold;
                }
            }

            string events = string.Empty;

            while ((events = Console.ReadLine()) != "End")
            {
                string[] eventsArr = events.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string action = eventsArr[0];
                string city = eventsArr[1];

                if (action == "Plunder")
                {
                    int people = int.Parse(eventsArr[2]);
                    int gold = int.Parse(eventsArr[3]);

                    cityInfoDic[city].Population -= people;
                    cityInfoDic[city].Gold -= gold;

                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (cityInfoDic[city].Population <= 0 || cityInfoDic[city].Gold <= 0)
                    {
                        cityInfoDic.Remove(city);
                        Console.WriteLine($"{city} has been wiped off the map!");
                    }
                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(eventsArr[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                        continue;
                    }

                    cityInfoDic[city].Gold += gold;

                    Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cityInfoDic[city].Gold} gold.");

                }
            }

            if (cityInfoDic.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityInfoDic.Count} wealthy settlements to go to:");

                foreach (var town in cityInfoDic.OrderByDescending(x => x.Value.Gold).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value.Population} citizens, Gold: {town.Value.Gold} kg");
                }
            }
        }
    }
}
