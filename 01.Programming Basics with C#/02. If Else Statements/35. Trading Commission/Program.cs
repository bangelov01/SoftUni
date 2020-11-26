using System;

namespace _35._Trading_Commission
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double salesAmount = double.Parse(Console.ReadLine());
            
            switch (city)
            {
                case "Sofia":
                    if (salesAmount >= 0 && salesAmount <=500)
                    {
                        Console.WriteLine($"{salesAmount * 5 / 100:f2}");
                    }
                    else if (salesAmount >= 500 && salesAmount <=1000)
                    {
                        Console.WriteLine($"{salesAmount * 7 / 100:f2}");
                    }
                    else if (salesAmount > 1000 && salesAmount <= 10000)
                    {
                        Console.WriteLine($"{salesAmount * 8 / 100:f2}");
                    }
                    else if (salesAmount > 10000)
                    {
                        Console.WriteLine($"{salesAmount * 12 / 100:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }                       break;
                case "Varna":
                    if (salesAmount >= 0 && salesAmount <= 500)
                    {
                        Console.WriteLine($"{salesAmount * 4.5 / 100:f2}");
                    }
                    else if (salesAmount >= 500 && salesAmount <= 1000)
                    {
                        Console.WriteLine($"{salesAmount * 7.5 / 100:f2}");
                    }
                    else if (salesAmount > 1000 && salesAmount <= 10000)
                    {
                        Console.WriteLine($"{salesAmount * 10 / 100:f2}");
                    }
                    else if (salesAmount > 10000)
                    {
                        Console.WriteLine($"{salesAmount * 13 / 100:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }                    break;
                case "Plovdiv":
                    if (salesAmount >= 0 && salesAmount <= 500)
                    {
                        Console.WriteLine($"{salesAmount * 5.5 / 100:f2}");
                    }
                    else if (salesAmount >= 500 && salesAmount <= 1000)
                    {
                        Console.WriteLine($"{salesAmount * 8 / 100:f2}");
                    }
                    else if (salesAmount > 1000 && salesAmount <= 10000)
                    {
                        Console.WriteLine($"{salesAmount * 12 / 100:f2}");
                    }
                    else if (salesAmount > 10000)
                    {
                        Console.WriteLine($"{salesAmount * 14.5 / 100:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
