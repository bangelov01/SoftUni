using System;

namespace _11._Division_Without_Reminder
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double count2 = 0;
            double count3 = 0;
            double count4 = 0;

            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (num % 2 == 0) count2++;
                if (num % 3 == 0) count3++;
                if (num % 4 == 0) count4++;
            }
            count2 /= n;
            count2 *= 100;
            count3 /= n;
            count3 *= 100;
            count4 /= n;
            count4 *= 100;

            Console.WriteLine($"{count2:f2}%\r\n{count3:f2}%\r\n{count4:f2}%");
        }
    }
}
