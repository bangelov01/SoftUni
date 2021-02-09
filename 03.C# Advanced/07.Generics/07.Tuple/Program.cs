using System;
using System.Collections.Generic;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            string town = string.Empty;
            if (input.Length == 5)
            {
                town = input[3] + " " + input[4];
            }
            else
            {
                town = input[3];
            }

            Tuple<string, string, string> tuple1 = new Tuple<string, string, string>(input[0] + " " + input[1], input[2], town);
            Console.WriteLine(tuple1);

            input = Console.ReadLine().Split();
            bool isDrunk = false;
            if (input[2] == "drunk")
            {
                isDrunk = true;
            }
            Tuple<string, int, bool> tuple2 = new Tuple<string, int, bool>(input[0], int.Parse(input[1]), isDrunk);
            Console.WriteLine(tuple2);

            input = Console.ReadLine().Split();
            Tuple<string, double, string> tuple3 = new Tuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(tuple3);
        }
    }
}
