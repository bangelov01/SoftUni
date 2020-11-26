using System;

namespace _21.Time
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            int leftFoodInKg = int.Parse(Console.ReadLine());
            double foodPerDayDogKg = double.Parse(Console.ReadLine());
            double foodPerDayCatKg = double.Parse(Console.ReadLine());
            double foodPerDayTurtleG = double.Parse(Console.ReadLine());

            double foodDailyDog = numberOfDays * foodPerDayDogKg;
            double foodDailyCat = numberOfDays * foodPerDayCatKg;
            double foodDailyTurtle = (foodPerDayTurtleG / 1000) * numberOfDays;
            double totalFood = foodDailyDog + foodDailyCat + foodDailyTurtle;

            if (leftFoodInKg >= totalFood)
            {
                double leftOverFood = leftFoodInKg - totalFood;
                Console.WriteLine($"{Math.Floor(leftOverFood)} kilos of food left.");
            }
            else
            {
                double neededFood = totalFood - leftFoodInKg;
                Console.WriteLine($"{Math.Ceiling(neededFood)} more kilos of food are needed.");
            }
        }
    }
}
