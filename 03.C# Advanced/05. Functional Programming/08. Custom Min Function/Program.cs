using System;
using System.Linq;

namespace _08._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> min = GetMin;

            int getNumber = min(numbers);

            Console.WriteLine(getNumber);
            
        }

        static int GetMin(int[] nums)
        {
            int minValue = int.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < minValue)
                {
                    minValue = nums[i];
                }
            }

            return minValue;
        }
    }
}
