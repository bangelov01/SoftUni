using System;

namespace _01._ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] commandArr = command.Split(">>>");

                string action = commandArr[0];

                if (action == "Contains")
                {
                    string substring = commandArr[1];

                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (action == "Flip")
                {
                    string upOrLow = commandArr[1];
                    int startIndex = int.Parse(commandArr[2]);
                    int endIndex = int.Parse(commandArr[3]);
                    int count = endIndex - startIndex;
                    string sub = activationKey.Substring(startIndex, count);

                    if (upOrLow == "Lower")
                    {
                        sub = sub.ToLower();
                    }
                    else
                    {
                        sub = sub.ToUpper();
                    }

                    activationKey = activationKey.Remove(startIndex, count).Insert(startIndex, sub);

                    Console.WriteLine($"{activationKey}");
                }               
                else if (action == "Slice")
                {
                    int startInd = int.Parse(commandArr[1]);
                    int endIndex = int.Parse(commandArr[2]);
                    int count = endIndex - startInd;
                    activationKey = activationKey.Remove(startInd, count);
                    Console.WriteLine($"{activationKey}");
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
