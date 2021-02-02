using System;
using System.Linq;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int useNum = num;
            string stringNum = "";
            stringNum += num;
            int sum = 0;

            for (int i = 0; i < stringNum.Length; i++)
            {
                int currentDigit = useNum % 10;
                useNum /= 10;

                int factorial = 1;

                for (int j = 1; j <= currentDigit; j++)
                {
                    factorial *= j;
                }
                sum += factorial;
            }

            if (num == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
