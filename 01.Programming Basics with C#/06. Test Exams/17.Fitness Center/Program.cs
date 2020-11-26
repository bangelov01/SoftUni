using System;

namespace _17.Fitness_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            ;
            double visitors = double.Parse(Console.ReadLine());
            int backCount = 0;
            int chestCount = 0;
            int legsCount = 0;
            int absCount = 0;
            int proteinCount = 0;
            int barCount = 0;
            int trainingCount = 0;
            int buyCount = 0;

            for (int i = 1; i <= visitors; i++)
            {
                string action = Console.ReadLine();

                switch (action)
                {
                    case "Back": 
                        backCount++;
                        trainingCount++;
                        break;
                    case "Chest": 
                        chestCount++;
                        trainingCount++;
                        break;
                    case "Legs": 
                        legsCount++;
                        trainingCount++;
                        break;
                    case "Abs": 
                        absCount++;
                        trainingCount++;
                        break;
                    case "Protein shake":
                        proteinCount++;
                        buyCount++;
                        break;
                    case "Protein bar":
                        barCount++;
                        buyCount++;
                        break;
                }
            }

            double percentTrain = trainingCount / visitors;
            percentTrain *= 100;

            double percentBuy = buyCount / visitors;
            percentBuy *= 100;

            Console.WriteLine($"{backCount} - back");
            Console.WriteLine($"{chestCount} - chest");
            Console.WriteLine($"{legsCount} - legs");
            Console.WriteLine($"{absCount} - abs");
            Console.WriteLine($"{proteinCount} - protein shake");
            Console.WriteLine($"{barCount} - protein bar");
            Console.WriteLine($"{percentTrain:f2}% - work out");
            Console.WriteLine($"{percentBuy:f2}% - protein");
        }
    }
}
