using System;

namespace _10._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double primeNumSum = 0;
            double nonPrimeNumSum = 0;
            while (input != "stop")
            {
                int num = int.Parse(input);
                bool flag = false;
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    flag = true;
                }
                if (flag != true)
                {
                    if (isPrime(num))
                    {
                        primeNumSum += num;
                    }
                    else
                    {
                        nonPrimeNumSum += num;
                    }

                    bool isPrime(int num)
                    {
                        if (num == 1)
                        {
                            return false;
                        }
                        if (num == 2)
                        {
                            return true;
                        }
                        if (num % 2 == 0)
                        {
                            return false;
                        }

                        for (int i = 3; i < num; i += 2)
                        {
                            if (num % i == 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
                
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeNumSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNumSum}");
        }
    }
}
