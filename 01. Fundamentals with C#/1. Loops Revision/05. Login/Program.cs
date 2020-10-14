using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            for (int i = username.Length-1; i >= 0; i--)
            {
                password += username[i];
            }

            string inputPass = Console.ReadLine();
            int tryCount = 0;

            while (inputPass != password)
            {
                tryCount++;
                if (tryCount >= 4)
                {
                    Console.WriteLine($"User {username} blocked! ");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again. ");
                inputPass = Console.ReadLine();
            }
            Console.WriteLine($"User {username} logged in. ");
        }
    }
}
