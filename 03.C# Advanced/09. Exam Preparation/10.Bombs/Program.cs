using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffects = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> effectQueue = new Queue<int>(bombEffects);

            int[] bombCasing = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> casingStack = new Stack<int>(bombCasing);

            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
                {"Cherry Bombs", 0 },
                {"Datura Bombs", 0 },
                {"Smoke Decoy Bombs", 0 }
            };

            while (effectQueue.Count > 0 && casingStack.Count > 0 && bombs.Values.Any(x => x < 3))
            {
                int effect = effectQueue.Peek();
                int casing = casingStack.Peek();

                int sum = effect + casing;
                string bomb = string.Empty;

                switch (sum)
                {
                    case 40:
                        bomb = "Datura Bombs";
                        bombs[bomb]++;
                        Remove(effectQueue, casingStack);
                        break;
                    case 60:
                        bomb = "Cherry Bombs";
                        bombs[bomb]++;
                        Remove(effectQueue, casingStack);
                        break;
                    case 120:
                        bomb = "Smoke Decoy Bombs";
                        bombs[bomb]++;
                        Remove(effectQueue, casingStack);
                        break;
                    default: int casingToReduce = casingStack.Pop();
                        casingToReduce -= 5;
                        casingStack.Push(casingToReduce);
                        break;
                }
            }

            if (bombs.Values.Any(x => x < 3))
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            if (effectQueue.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",effectQueue)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casingStack.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casingStack)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }

        public static void Remove(Queue<int> effectQueue, Stack<int> casingStack)
        {
            effectQueue.Dequeue();
            casingStack.Pop();
        }
    }
}
