using System;

namespace _01._test
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int sumNumber = 0;
            while (sumNumber < startNumber)
            {
                int secondNumber = int.Parse(Console.ReadLine());
                sumNumber += secondNumber;
            }
            Console.WriteLine(sumNumber);
        }
    }
}
