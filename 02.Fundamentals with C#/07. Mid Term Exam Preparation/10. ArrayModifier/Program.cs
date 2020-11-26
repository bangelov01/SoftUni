using System;
using System.Linq;

namespace _10._ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split();

                string action = commandArr[0];

                if (action == "swap")
                {
                    int indexOne = int.Parse(commandArr[1]);
                    int indexTwo = int.Parse(commandArr[2]);

                    int hold = integers[indexTwo];

                    integers[indexTwo] = integers[indexOne];

                    integers[indexOne] = hold;
                }
                else if (action == "multiply")
                {
                    int indexOne = int.Parse(commandArr[1]);
                    int indexTwo = int.Parse(commandArr[2]);

                    integers[indexOne] *= integers[indexTwo];
                }
                else
                {
                    for (int i = 0; i < integers.Length; i++)
                    {
                        integers[i] -= 1;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
