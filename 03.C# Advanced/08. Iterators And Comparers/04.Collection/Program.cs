using System;
using System.Linq;

namespace _04.Collection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> myListy = null;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                var parts = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (parts[0])
                {
                    case "Create":
                        myListy = new ListyIterator<string>(parts.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(myListy.Move());
                        break;
                    case "Print":
                        myListy.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(myListy.HasNext());
                        break;
                    case "PrintAll":
                        foreach (var item in myListy)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
