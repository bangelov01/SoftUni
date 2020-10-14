using System;

namespace _12.English_Name_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string numStr = "";

            int lastDigit = num % 10;

            switch (lastDigit)
            {
                case 0: numStr = "zero"; break;
                case 1: numStr = "one"; break;
                case 2: numStr = "two"; break;
                case 3: numStr = "three"; break;
                case 4: numStr = "four"; break;
                case 5: numStr = "five"; break;
                case 6: numStr = "six"; break;
                case 7: numStr = "seven"; break;
                case 8: numStr = "eight"; break;
                case 9: numStr = "nine"; break;
            }
            Console.WriteLine(numStr);
        }
    }
}
