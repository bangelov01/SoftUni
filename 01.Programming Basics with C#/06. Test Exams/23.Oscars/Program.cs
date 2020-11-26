using System;

namespace _23.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            double referees = double.Parse(Console.ReadLine());
            double neededPoints = 1250.5;
            bool win = false;
            int count = 0;

            while (count != referees)
            {
                string refereeName = Console.ReadLine();
                double refereePoints = double.Parse(Console.ReadLine());

                double addedPoints = (refereeName.Length * refereePoints) / 2;
                points += addedPoints;
                if (points > 1250.5)
                {
                    win = true;
                    break;
                }
                count++;
            }
            if (win)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {points:f1}!");
            }
            else
            {
                neededPoints -= points;
                Console.WriteLine($"Sorry, {actorName} you need {neededPoints:f1} more!");
            }
        }
    }
}
