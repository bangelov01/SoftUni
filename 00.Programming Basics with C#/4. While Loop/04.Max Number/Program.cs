using System;

namespace _04.Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxVavue = int.MinValue;

            while (input != "Stop")
            {
                int num = int.Parse(input);
                if (num > maxVavue)
                {
                    maxVavue = num;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(maxVavue);
        }
    }
}
