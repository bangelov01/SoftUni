using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyAmount = double.Parse(Console.ReadLine()); 
            double studentCount = double.Parse(Console.ReadLine());
            double lightPrice = double.Parse(Console.ReadLine());       //all prices for single item
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double lightPercent = Math.Ceiling(studentCount * 0.10);
            double freeBelts = Math.Floor(studentCount / 6);
            double neededEquipment = lightPrice * (studentCount + lightPercent) + robesPrice * studentCount + beltsPrice * (studentCount - freeBelts);

            if (neededEquipment > moneyAmount)
            {
                Console.WriteLine($"Ivan Cho will need {neededEquipment-=moneyAmount:f2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {neededEquipment:f2}lv.");
            }
        }
    }
}
