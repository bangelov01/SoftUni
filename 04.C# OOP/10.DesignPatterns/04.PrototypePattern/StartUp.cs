using _04.PrototypePattern.Models;
using _04.PrototypePattern.Repositories;
using System;

namespace _04.PrototypePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new();

            sandwichMenu["Turkey"] = new Sandwich("Wheat", "Bacon", "Gauda", "Lettuce, Tomato");
            sandwichMenu["BLT"] = new Sandwich("White", "Turkey", "Swiss", "Lettuce");

            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["Turkey"].Clone() as Sandwich;

        }
    }
}
