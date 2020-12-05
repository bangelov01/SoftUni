using System;
using System.Linq;

namespace _07._SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string instructions = string.Empty;

            while ((instructions = Console.ReadLine()) != "Reveal")
            {
                string[] instrArr = instructions.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string command = instrArr[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(instrArr[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine($"{message}");
                }
                else if (command == "Reverse")
                {
                    string sub = instrArr[1];

                    if (message.Contains(sub))
                    {
                        int index = message.IndexOf(sub);
                        message = message.Remove(index, sub.Length);
                        for (int i = sub.Length - 1; i >= 0; i--)
                        {
                            message += sub[i];
                        }
                        Console.WriteLine($"{message}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    string sub = instrArr[1];
                    string repl = instrArr[2];

                    message = message.Replace(sub, repl);
                    Console.WriteLine($"{message}");
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
