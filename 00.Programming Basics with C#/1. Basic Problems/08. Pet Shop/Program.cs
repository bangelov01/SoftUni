using System;

namespace _08._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDogs = int.Parse(Console.ReadLine());
            int numberOfOtherAnimals = int.Parse(Console.ReadLine());
            double totalAmount = (numberOfDogs * 2.50) + (numberOfOtherAnimals * 4);

            Console.WriteLine($"{totalAmount} lv.");
        }
    }
}
