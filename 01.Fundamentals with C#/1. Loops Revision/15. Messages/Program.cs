using System;

namespace _15._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int loopTime = int.Parse(Console.ReadLine());
            int count = 0;
            string save = String.Empty;
            int ascii = 0;

            while (count != loopTime)
            {
                int num = int.Parse(Console.ReadLine());

                string convert = Convert.ToString(num);

                int digitLength = convert.Length;

                Convert.ToInt32(num);

                int mainDigit = num % 10;

                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset += 1;
                }

                int letterIndex = (offset + digitLength - 1);

                if (num == 0)
                {
                    ascii = 32;
                }
                else
                {
                    ascii = 97 + letterIndex;
                }

                char convertChar = Convert.ToChar(ascii);

                save += convertChar;

                count++;
            }
            Console.WriteLine(save);
        }
    }
}
