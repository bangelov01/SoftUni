using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList myList = new RandomList();

            myList.Add("Pesho");
            myList.Add("Gosho");
            myList.Add("Dido");

            Console.WriteLine(myList.RandomString());
        }
    }
}
