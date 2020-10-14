using System;

namespace _35._Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            byte numberOfLines = byte.Parse(Console.ReadLine());
            string output = string.Empty;

            for (int i = 1; i <= numberOfLines; i++)
            {
                char inputChar = char.Parse(Console.ReadLine());
                byte charConvert = Convert.ToByte(inputChar);

                charConvert += key;

                char decryptChar = Convert.ToChar(charConvert);
                output += decryptChar;
            }
            Console.WriteLine(output);
        }
    }
}
