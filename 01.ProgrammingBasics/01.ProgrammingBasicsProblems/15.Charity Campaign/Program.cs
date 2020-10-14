using System;

namespace _15.Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int campdays = int.Parse(Console.ReadLine());
            int cooks = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakesum = 45;
            double wafflesum = 5.80;
            double pancakesum = 3.20;

            double cakesdaysum = cakes * cakesum;
            double wafflesdaysum = waffles * wafflesum;
            double pancakesdaysum = pancakes * pancakesum;

            double onedaysum = (cakesdaysum + wafflesdaysum + pancakesdaysum) * cooks;
            double wholesum = onedaysum * campdays;
            double aftercosts = wholesum - (wholesum / 8);

            Console.WriteLine(aftercosts);
        }
    }
}
