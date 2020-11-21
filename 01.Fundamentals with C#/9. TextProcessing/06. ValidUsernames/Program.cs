using System;
using System.Text;

namespace _06._ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var userName in userNames)
            {
                StringBuilder output = new StringBuilder();

                if (userName.Length >= 3 && userName.Length <= 16)
                {
                    for (int i = 0; i < userName.Length; i++)
                    {
                        if (char.IsLetterOrDigit(userName[i])
                            || userName[i] == '-' || userName[i] == '_')
                        {
                            output.Append(userName[i]);
                        }
                    }
                    if (output.ToString() == userName)
                    {
                        Console.WriteLine(output);
                    }
                }
            }
        }
    }
}
