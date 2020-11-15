using System;
using System.Collections.Generic;

namespace _10._SoftuniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEntries = int.Parse(Console.ReadLine());

            Dictionary<string, string> registeredVehicles = new Dictionary<string, string>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                string[] command = Console.ReadLine().Split(" ");

                string commandType = command[0];

                string name = command[1];

                if (commandType == "register")
                {
                    string licenseNum = command[2];

                    if (!registeredVehicles.ContainsKey(name))
                    {
                        registeredVehicles.Add(name, licenseNum);
                        Console.WriteLine($"{name} registered {registeredVehicles[name]} successfully");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registeredVehicles[name]}");
                    }
                }
                else
                {
                    if (!registeredVehicles.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                        continue;
                    }
                    else
                    {
                        registeredVehicles.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }

            foreach (var item in registeredVehicles)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
