using System;

namespace _04.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());

            for (int i = 0; i < times; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> newBox = new Box<int>(input);
                Console.WriteLine(newBox.ToString());
            }
        }
    }
}
