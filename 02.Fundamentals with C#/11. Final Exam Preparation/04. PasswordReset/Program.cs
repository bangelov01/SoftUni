using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseString = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] inputArr = input.Split(" ");

                string command = inputArr[0];

                if (command == "TakeOdd")
                {
                    string newString = string.Empty;
                    for (int i = 0; i < baseString.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            newString += baseString[i];
                        }
                    }
                    baseString = newString;
                    Console.WriteLine($"{baseString}");
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(inputArr[1]);
                    int length = int.Parse(inputArr[2]);

                    baseString = baseString.Remove(index, length);
                    Console.WriteLine($"{baseString}");
                }
                else if (command == "Substitute")
                {
                    string sub = inputArr[1];
                    string substitute = inputArr[2];

                    if (baseString.Contains(sub))
                    {
                        baseString = baseString.Replace(sub, substitute);
                        Console.WriteLine($"{baseString}");
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {baseString}");
        }
    }
}
