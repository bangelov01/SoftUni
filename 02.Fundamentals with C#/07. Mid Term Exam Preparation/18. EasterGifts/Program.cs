using System;
using System.Collections.Generic;
using System.Linq;

namespace _18._EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> giftsToBuy = Console.ReadLine().Split(" ").ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "No Money")
            {
                string[] commandArr = command.Split();

                string action = commandArr[0];
                string gift = commandArr[1];

                if (action == "OutOfStock")
                {
                    if (giftsToBuy.Exists(x => x == gift))
                    {
                        for (int i = 0; i < giftsToBuy.Count; i++)
                        {
                            if (giftsToBuy[i] == gift)
                            {
                                giftsToBuy[i] = "None";
                            }
                        }
                    }
                }
                else if (action == "Required")
                {
                    int index = int.Parse(commandArr[2]);
                    if (index >= 0 && index <= giftsToBuy.Count - 1)
                    {
                        giftsToBuy[index] = gift;
                    }
                }
                else if (action == "JustInCase")
                {
                    giftsToBuy.RemoveAt(giftsToBuy.Count - 1);
                    giftsToBuy.Add(gift);
                }
            }

            Console.WriteLine(string.Join(" ", giftsToBuy.Where(x => x != "None")));
        }
    }
}
