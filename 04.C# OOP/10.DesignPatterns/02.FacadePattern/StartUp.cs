using _02.FacadePattern.Facade;
using System;

namespace _02.FacadePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                    .WithType("Mazda")
                    .WithColor("Grey")
                    .WithNumberOfDoors(5)
                .Built
                    .InCity("Tokyo")
                    .AtAddress("MazdaCorp Street")
                .Build();

            Console.WriteLine(car);
        }
    }
}
