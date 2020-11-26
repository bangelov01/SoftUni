using System;

namespace _12.Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal depositsum = decimal.Parse(Console.ReadLine());
            int deposittime = int.Parse(Console.ReadLine());
            decimal yearpercentage = decimal.Parse(Console.ReadLine());
            decimal yearpercentageconvert = yearpercentage / 100;


            decimal gainedinterest = depositsum * yearpercentageconvert;
            decimal monthlyinterestrate = gainedinterest / 12;
            decimal sumplusinterest = depositsum + (deposittime * monthlyinterestrate);

            Console.WriteLine(sumplusinterest);
        }
    }
}
