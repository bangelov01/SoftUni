using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBox = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> firstQueue = new Queue<int>(firstBox);

            int[] secondBox = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> secondStack = new Stack<int>(secondBox);

            List<int> claimedItems = new List<int>();

            while (firstQueue.Count > 0 && secondStack.Count > 0)
            {
                int queueNum = firstQueue.Peek();
                int stackNum = secondStack.Pop();

                int sum = queueNum + stackNum;

                if (sum % 2 == 0)
                {
                    claimedItems.Add(sum);
                    firstQueue.Dequeue();
                }
                else
                {
                    firstQueue.Enqueue(stackNum);
                }
            }

            if (firstQueue.Count <= 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (secondStack.Count <= 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int finalSum = claimedItems.Sum();

            if (finalSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {finalSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {finalSum}");
            }
        }
    }
}
