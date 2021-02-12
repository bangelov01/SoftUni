using System;
using System.Linq;

namespace _05.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MyStack<int> newStack = new MyStack<int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split(new string[] {" ", ", "}, StringSplitOptions.RemoveEmptyEntries);

                switch (parts[0])
                {
                    case "Push":
                        int[] itemsToPush = parts.Skip(1).Select(int.Parse).ToArray();
                        for (int i = 0; i < itemsToPush.Length; i++)
                        {
                            newStack.Push(itemsToPush[i]);
                        }
                        break;
                    case "Pop":
                        try
                        {
                            newStack.Pop();
                        }
                        catch
                        {
                            Console.WriteLine("No elements");
                        }                       
                        break;
                }
            }

            foreach (var item in newStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in newStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
