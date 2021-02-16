using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> liliesStack = new Stack<int>(lilies);

            int[] roses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> rosesQueue = new Queue<int>(roses);

            int wreathCunt = 0;
            int storedSum = 0;

            while (liliesStack.Count > 0 && rosesQueue.Count > 0)
            {
                int lily = liliesStack.Peek();
                int rose = rosesQueue.Peek();

                int sum = lily + rose;

                if (sum == 15)
                {
                    wreathCunt++;
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }
                else if (sum > 15)
                {
                    int numToDecrease = liliesStack.Pop();
                    numToDecrease -= 2;
                    liliesStack.Push(numToDecrease);
                }
                else
                {
                    int lilyForSum = liliesStack.Pop();
                    int roseForSum = rosesQueue.Dequeue();

                    lilyForSum += roseForSum;

                    storedSum += lilyForSum;
                }
            }

            int numOfBonusWreaths = storedSum / 15;
            wreathCunt += numOfBonusWreaths;

            if (wreathCunt >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCunt} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCunt} wreaths more!");
            }
        }
    }
}
