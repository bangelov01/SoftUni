using System;

namespace _24._Sum_Of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numberOfLines = byte.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                int intSymbol = Convert.ToInt32(symbol);
                sum += intSymbol;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
