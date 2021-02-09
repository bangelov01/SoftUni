using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> myDoublyList = new DoublyLinkedList<string>();

            myDoublyList.AddFirst("AC/DC");
            myDoublyList.AddLast("WhiteSnake");
            myDoublyList.AddLast("Scorpions");
            myDoublyList.AddLast("DeepPurple");

            var array = myDoublyList.ToArray();

            myDoublyList.ForEach(x => Console.WriteLine(x));

            var lastElement = myDoublyList.RemoveLast();
        }
    }
}
