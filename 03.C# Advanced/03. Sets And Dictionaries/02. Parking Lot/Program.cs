using System;
using System.Collections.Generic;

namespace _02._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            HashSet<string> plateSet = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] carInfo = input.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string direction = carInfo[0];
                string plate = carInfo[1];

                if (direction == "IN")
                {
                    if (!plateSet.Contains(plate))
                    {
                        plateSet.Add(plate);
                    }
                }
                else if (direction == "OUT")
                {
                    if (plateSet.Contains(plate))
                    {
                        plateSet.Remove(plate);
                    }
                }
            }
            if (plateSet.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var plate in plateSet)
                {
                    Console.WriteLine(plate);
                }
            }
        }
    }
}
