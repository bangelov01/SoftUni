using System;

namespace _13._LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal sum = 0.00m;

            foreach (var word in strings)
            {
                int positionLedt = word[0] % 32;
                int positionRight = word[word.Length - 1] % 32;
                string sub = word.Substring(1, word.Length - 2);
                decimal convert = decimal.Parse(sub);
                decimal innerSum = 0.00m;

                if (char.IsUpper(word[0]))
                {
                    innerSum = convert / positionLedt;
                }
                else
                {
                    innerSum = convert * positionLedt;
                }
                if (char.IsUpper(word[word.Length - 1]))
                {
                    decimal result = innerSum - positionRight;
                    sum += result;
                }
                else
                {
                    decimal result = innerSum + positionRight;
                    sum += result;
                }
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
