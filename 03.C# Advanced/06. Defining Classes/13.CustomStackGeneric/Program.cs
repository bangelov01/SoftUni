using System;
using System.Collections.Generic;

namespace _13.CustomStackGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> myStack = new CustomStack<string>();

            string[] names = new string[5] { "Miko", "Pesho", "Stamat", "Gatio", "Petko" };

            foreach (var name in names)
            {
                myStack.Push(name);
            }

            string nameToSearch = "Pesho";

            for (int i = 0; i < myStack.Count; i++)
            {
                string item = myStack.Peek();

                if (item != nameToSearch)
                {
                    myStack.Pop();
                }
                else
                {
                    break;
                }
            }

            myStack.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }
    }
}
