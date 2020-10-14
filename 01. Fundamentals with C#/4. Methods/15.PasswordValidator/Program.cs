using System;
using System.Linq;

namespace _15.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            ReturnPasswordValidation(password);
        }

        static void ReturnPasswordValidation(string password)
        {
            bool isValid = true;

            if (password.Length < 6 || password.Length > 10)
            {
                isValid = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!ReturnLettersDigitsTest(password))
            {
                isValid = false;
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!ReturnDigitsTest(password))
            {
                isValid = false;
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool ReturnLettersDigitsTest(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 48 && password[i] <= 57) || 
                    (password[i] >= 65 && password[i] <= 90) ||
                    (password[i] >= 97 && password[i] <= 122))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        static bool ReturnDigitsTest(string text)
        {
            int digitCount = 0;
            char[] digits = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            for (int i = 0; i < text.Length; i++)
            {
                if (digits.Contains(text[i]))
                {
                    digitCount++;
                }
            }
            if (digitCount < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
