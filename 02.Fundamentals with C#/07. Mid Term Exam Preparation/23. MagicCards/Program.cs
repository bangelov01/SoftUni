using System;
using System.Collections.Generic;
using System.Linq;

namespace _23._MagicCards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> deck = new List<string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Ready")
            {
                string[] commandArr = command.Split();

                string action = commandArr[0];

                string cardName = commandArr[1];

                if (action == "Add")
                {
                    if (cards.Exists(x => x == cardName))
                    {
                        deck.Add(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(commandArr[2]);

                    if (cards.Exists(x => x == cardName) && index >=0 && index <= deck.Count - 1)
                    {
                        deck.Insert(index, cardName);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                else if (action == "Remove")
                {
                    if (deck.Exists(x => x == cardName))
                    {
                        deck.Remove(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (action == "Swap")
                {
                    string cardTwo = commandArr[2];

                    int indexCardOne = deck.IndexOf(cardName);
                    int indexCardTwo = deck.IndexOf(cardTwo);

                    string hold = deck[indexCardTwo];
                    deck[indexCardTwo] = deck[indexCardOne];
                    deck[indexCardOne] = hold;
                }
                else if (action == "Shuffle" && cardName == "deck")
                {
                    deck.Reverse();
                }
            }

            Console.WriteLine(string.Join(" ", deck));
        }
    }
}
