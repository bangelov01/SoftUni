using _05.Telephony.Interfaces;
using System;
using System.Linq;

namespace _05.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable smartPhone = new SmartPhone();
            ICallable stationaryPhone = new StationaryPhone();
            IBrowsable smartPhoneBrowse = new SmartPhone();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].Any(char.IsLetter))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                if (numbers[i].Length == 10)
                {
                    Console.WriteLine(smartPhone.Call(numbers[i]));
                }
                else
                {
                    Console.WriteLine(stationaryPhone.Call(numbers[i]));
                }
            }

            for (int i = 0; i < urls.Length; i++)
            {
                if (urls[i].Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine(smartPhoneBrowse.Browse(urls[i]));
                }
            }
        }
    }
}
