using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _17._SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operationsNumber = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            Stack<string> state = new Stack<string>();

            state.Push(text.ToString());

            for (int i = 0; i < operationsNumber; i++)
            {
                string[] input = Console.ReadLine().Split();

                int command = int.Parse(input[0]);

                if (command == 1)
                {
                    string toAopend = input[1];
                    text.Append(toAopend);
                    state.Push(text.ToString());
                }
                else if (command == 2)
                {
                    int countToErase = int.Parse(input[1]);
                    text.Remove(text.Length - countToErase, countToErase);
                    state.Push(text.ToString());
                }
                else if (command == 3)
                {
                    int elementIndex = int.Parse(input[1]);
                    Console.WriteLine(text[elementIndex - 1]);
                }
                else
                {
                    state.Pop();
                    text.Clear();
                    text.Append(state.Peek());
                }
            }
        }
    }
}
