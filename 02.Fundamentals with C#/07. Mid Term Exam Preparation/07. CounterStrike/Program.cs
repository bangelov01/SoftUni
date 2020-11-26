using System;

namespace _07._CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());

            string distance = string.Empty;

            int wonBattles = 0;
            bool isLost = false;

            while ((distance = Console.ReadLine()) != "End of battle")
            {
                int neededEnergy = int.Parse(distance);

                if (neededEnergy > initialEnergy)
                {
                    isLost = true;
                    break;
                }
                else
                {
                    initialEnergy -= neededEnergy;
                    wonBattles++;
                    if (wonBattles % 3 == 0)
                    {
                        initialEnergy += wonBattles;
                    }
                }
            }
            if (isLost)
            {
                Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {initialEnergy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {wonBattles}. Energy left: {initialEnergy}");
            }
        }
    }
}
