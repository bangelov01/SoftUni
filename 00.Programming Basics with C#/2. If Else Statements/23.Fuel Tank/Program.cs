using System;

namespace _23.Fuel_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string typeOfFuel = Console.ReadLine();
            double litresFuelInTank = double.Parse(Console.ReadLine());


            if (litresFuelInTank >= 25 && typeOfFuel == "Diesel" || typeOfFuel == "Gasoline" || typeOfFuel == "Gas")
            {
                string fuel = typeOfFuel.ToLower();

                Console.WriteLine($"You have enough {fuel}.");
            }
            else if (litresFuelInTank < 25 && typeOfFuel == "Diesel" || typeOfFuel == "Gasoline" || typeOfFuel == "Gas")
            {
                string fuel = typeOfFuel.ToLower();

                Console.WriteLine($"Fill your tank with {fuel}!");
            }
            else if (typeOfFuel != "Diesel" && typeOfFuel != "Gasoline" && typeOfFuel != "Gas")
            {
                Console.WriteLine("Invalid fuel!");
            }
            */
            string typeOfFuel = Console.ReadLine().ToLower();
            int litresFuelInTank = int.Parse(Console.ReadLine());

            if (typeOfFuel == "diesel" || typeOfFuel == "gas" || typeOfFuel == "gasoline")
            {
                if (litresFuelInTank >= 25)
                {
                    Console.WriteLine($"You have enough {typeOfFuel}.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with {typeOfFuel}!");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}
