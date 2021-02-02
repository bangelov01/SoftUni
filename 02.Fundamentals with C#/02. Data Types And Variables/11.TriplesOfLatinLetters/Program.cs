using System;

namespace _26.Triples_Of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    for (int k = 0; k < number; k++)
                    {
                        char a = (char)('a' + i);
                        char b = (char)('a' + j);
                        char c = (char)('a' + k);
                        Console.WriteLine($"{a}{b}{c}");
                    }
                }
            }
        }
    }
}
