using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _13._TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int waitingPeopleNum = int.Parse(Console.ReadLine());

            List<int> currentSttae = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            bool noPeopleWaiting = false;

            for (int i = 0; i < currentSttae.Count; i++)
            {
                if (currentSttae[i] >= 4)
                {
                    continue;
                }
                while (currentSttae[i] < 4)
                {
                    waitingPeopleNum -= 1;
                    currentSttae[i] += 1;
                    if (waitingPeopleNum <= 0)
                    {
                        noPeopleWaiting = true;
                        break;
                    }
                }
                if (noPeopleWaiting)
                {
                    break;
                }
            }

            if (noPeopleWaiting == true && currentSttae.Exists(x => x < 4))
            {
                Console.WriteLine($"The lift has empty spots!\r\n{string.Join(" ", currentSttae)}");
            }
            else if (noPeopleWaiting == false && currentSttae.All(x => x == 4))
            {
                Console.WriteLine($"There isn't enough space! {waitingPeopleNum} people in a queue!\r\n{string.Join(" ", currentSttae)}");
            }
            else if (currentSttae.All(x => x == 4) && noPeopleWaiting == true)
            {
                Console.WriteLine(string.Join(" ", currentSttae));
            }
        }
    }
}
