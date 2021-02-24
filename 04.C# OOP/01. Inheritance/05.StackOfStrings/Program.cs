using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();
            myStack.Push("pesho");
            myStack.Push("gosho");
            myStack.Push("petko");

            myStack.AddRange("ani", "didi", "mishi");

            Console.WriteLine(string.Join(" ",myStack));
        }
    }
}
