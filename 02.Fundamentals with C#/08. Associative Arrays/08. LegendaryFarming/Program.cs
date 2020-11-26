using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split(" ");

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials["motes"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["shards"] = 0;
            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();
            bool isObtained = false;

            while (true)
            {
                for (int i = 0; i < items.Length; i+=2)
                {
                    int quantity = int.Parse(items[i]);
                    string item = items[i + 1].ToLower();

                    if (item == "motes" || item == "fragments" || item == "shards")
                    {
                        keyMaterials[item] += quantity;

                        if (keyMaterials[item] >= 250)
                        {
                            keyMaterials[item] -= 250;
                            if (item == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (item == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            else if (item == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }

                            isObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(item))
                        {
                            junkMaterials.Add(item, quantity);
                        }
                        else
                        {
                            junkMaterials[item] += quantity;
                        }
                    }
                }

                if (isObtained)
                {
                    break;
                }

                items = Console.ReadLine().Split(" ");
            }

            foreach (var item in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junkMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
