using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOneCards = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();

            List<int> playerTwoCards = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();

            int sumPlayerOne = playerOneCards.Sum();
            int sumPlayerTwo = playerTwoCards.Sum();

            for (int i = 0; i < playerOneCards.Count; i++)
            {
                if (playerOneCards[i] > playerTwoCards[i])
                {
                    int firstCardHolder = playerOneCards[i];
                    playerOneCards.Add(firstCardHolder);
                    playerOneCards.Add(playerTwoCards[i]);
                }
                else if (playerOneCards[i] < playerTwoCards[i])
                {
                    int secondCardHoler = playerTwoCards[i];
                    playerTwoCards.Add(secondCardHoler);
                    playerTwoCards.Add(playerOneCards[i]);
                }

                playerTwoCards.RemoveAt(i);
                playerOneCards.RemoveAt(i);

                if (playerTwoCards.Count <= 0)
                {
                    Console.WriteLine($"First player wins! Sum: {playerOneCards.Sum()}");
                    return;
                }
                i = -1;
            }
            Console.WriteLine($"Second player wins! Sum: {playerTwoCards.Sum()}");
        }
    }
}
