using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace _20.PilandromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = string.Empty;

            while ((number = Console.ReadLine()) != "END")
            {
                int[] inputArr = new int[number.Length];

                for (int i = 0; i < number.Length; i++)
                {
                    inputArr[i] = int.Parse(number[i].ToString());
                }

                int[] reverseArr = new int[inputArr.Length];

                if (ReturnIfArrayIsPolindrome(inputArr, reverseArr))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool ReturnIfArrayIsPolindrome(int[] arr1, int[] arr2)
        {
            arr1.CopyTo(arr2, 0);

            Array.Reverse(arr2);

            return Enumerable.SequenceEqual(arr1, arr2);
        }
    }
}
