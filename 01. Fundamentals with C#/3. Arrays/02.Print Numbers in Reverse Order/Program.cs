using System;

namespace _02.Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNums = int.Parse(Console.ReadLine());

            int[] arrNum = new int[numberOfNums];

            for (int i = 0; i < numberOfNums; i++)
            {
                int number = int.Parse(Console.ReadLine());
                arrNum[i] = number;
            }

            for (int i = arrNum.Length-1; i >= 0; i--)
            {
                Console.Write($"{arrNum[i]} ");
            }
        }
    }
}
