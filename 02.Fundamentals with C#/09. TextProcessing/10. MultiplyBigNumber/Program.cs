using System;
using System.Linq;
using System.Text;

namespace _10._MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine().TrimStart('0');
            int multiplier = int.Parse(Console.ReadLine());

            if (bigNumber == "" || multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder output = new StringBuilder();

            int remainder = 0;

            foreach (var digit in bigNumber.Reverse())
            {
                int num = int.Parse(digit.ToString());

                int result = num * multiplier + remainder;

                int leftDigit = result % 10;

                remainder = result / 10;

                output.Insert(0, leftDigit);

            }

            if (remainder > 0)
            {
                output.Insert(0, remainder);
            }

            Console.WriteLine(output);
        }
    }
}
