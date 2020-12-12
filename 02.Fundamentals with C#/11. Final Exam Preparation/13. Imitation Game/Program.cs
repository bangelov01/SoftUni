using System;

namespace _13._Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] commandArr = command.Split("|", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArr[0];

                if (action == "Move")
                {
                    int numLetters = int.Parse(commandArr[1]);

                    string sub = message.Substring(0, numLetters);
                    message = message.Remove(0, numLetters);
                    message += sub;
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(commandArr[1]);
                    string value = commandArr[2];

                    message = message.Insert(index, value);
                }
                else if (action == "ChangeAll")
                {
                    string sub = commandArr[1];
                    string replacement = commandArr[2];

                    message = message.Replace(sub, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
