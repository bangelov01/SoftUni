using System;

namespace _22._Movie_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            double actorBudget = double.Parse(Console.ReadLine());
            bool action = false;

            for (int i = 1; actorBudget > 0; i++)
            {
                string actorName = Console.ReadLine();
                if (actorName == "ACTION")
                {
                    action = true;
                    break;
                }
                if (actorName.Length > 15)
                {
                    double percent = actorBudget * 0.20;
                    actorBudget -= percent;
                    continue;
                }
                double salary = double.Parse(Console.ReadLine());
                actorBudget -= salary;
            }
            if (action)
            {
                Console.WriteLine($"We are left with {actorBudget:f2} leva."
);
            }
            else
            {
                Console.WriteLine($"We need {actorBudget*-1:f2} leva for our actors."
);
            }
        }
    }
}
