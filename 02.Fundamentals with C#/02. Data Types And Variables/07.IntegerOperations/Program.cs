using System;

namespace _22.Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sumofDigits = 0;

            for (int i = 0; i < number.Length; i++)
            {
                string convert = Convert.ToString(number[i]);
                int num = int.Parse(convert);
                sumofDigits += num;
            }
            Console.WriteLine(sumofDigits);
        }
    }
}
