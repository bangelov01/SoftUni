using System;
using System.Collections.Generic;

namespace _03._Softuni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string guestNumber = string.Empty;

            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            bool partyMode = false;

            while ((guestNumber = Console.ReadLine()) != "END")
            {
                if (guestNumber == "PARTY")
                {
                    partyMode = true;
                    continue;
                }
                if (!partyMode)
                {
                    if (char.IsDigit(guestNumber[0]))
                    {
                        vip.Add(guestNumber);
                    }
                    else
                    {
                        regular.Add(guestNumber);
                    }
                }
                else
                {
                    if (vip.Contains(guestNumber))
                    {
                        vip.Remove(guestNumber);
                    }
                    else if (regular.Contains(guestNumber))
                    {
                        regular.Remove(guestNumber);
                    }
                }
            }
            int guestWhoCame = vip.Count + regular.Count;
            Console.WriteLine(guestWhoCame);
            foreach (var vipPerson in vip)
            {
                Console.WriteLine(vipPerson);
            }
            foreach (var regularPerson in regular)
            {
                Console.WriteLine(regularPerson);
            }
        }
    }
}
