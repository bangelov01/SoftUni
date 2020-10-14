using System;

namespace _31.Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                bool isInteger = int.TryParse(input, out int integer);
                bool isFloating = float.TryParse(input, out float floating);
                bool isChar = char.TryParse(input, out char character);
                bool isBool = bool.TryParse(input, out bool type);

                if (isInteger)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (isFloating)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (isChar)
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (isBool)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                input = Console.ReadLine();
            }
        }
    }
}
