using System;

namespace _14.Birthday_party
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double cake = rent * 0.2;
            double cakeper = cake * 0.45;
            double drinks = cake - cakeper;
            double anim = rent / 3;

            Console.WriteLine(rent + cake + drinks + anim);
        }
    }
}
