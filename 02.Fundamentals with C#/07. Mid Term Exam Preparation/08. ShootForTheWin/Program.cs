using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targetValue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string indices = string.Empty;

            while ((indices = Console.ReadLine()) != "End")
            {
                int index = int.Parse(indices);

                if (index > targetValue.Count - 1 || targetValue[index] == -1)
                {
                    continue;
                }

                int saveValue = targetValue[index];

                targetValue[index] = -1;

                for (int i = 0; i < targetValue.Count; i++)
                {
                    if (targetValue[i] == -1)
                    {
                        continue;
                    }

                    if (targetValue[i] > saveValue)
                    {
                        targetValue[i] -= saveValue;
                    }
                    else
                    {
                        targetValue[i] += saveValue;
                    }
                }
            }

            int shotTargets = targetValue.Where(x => x == -1).Count();

            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ", targetValue)}");
        }
    }
}
