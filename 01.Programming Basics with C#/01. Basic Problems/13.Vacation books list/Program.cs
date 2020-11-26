using System;

namespace _13.Vacation_books_list
{
    class Program
    {
        static void Main(string[] args)
        {
            int pagenumber = int.Parse(Console.ReadLine());
            double pagesperhour = double.Parse(Console.ReadLine());
            int daystoreadall = int.Parse(Console.ReadLine());

            double neededhoursperday = pagenumber / pagesperhour;
            double hoursperday = neededhoursperday / daystoreadall;


            Console.WriteLine(hoursperday);
        }
    }
}
