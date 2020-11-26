using System;

namespace _12._StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int bombPower = 0;

            int index = input.IndexOf('>');

            for (int i = index; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    bombPower += int.Parse(input[i + 1].ToString());
                }
                else
                {
                    if (bombPower > 0)
                    {
                        input = input.Remove(i, 1);
                        i--;
                        bombPower--;
                    }
                }
            }

            Console.WriteLine(input);
        }
    }
}


