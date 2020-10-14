using System;

namespace _32.Fruits_And_Vegetables
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string type = "";
            switch (product)
            {
                case "banana":
                case "apple":
                case "kiwi":
                case "cherry":
                case "lemon":
                case "grapes":
                    type = "fruit"; break;
                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot":
                    type = "vegetable"; break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
            Console.WriteLine(type);
        }
    }
}
