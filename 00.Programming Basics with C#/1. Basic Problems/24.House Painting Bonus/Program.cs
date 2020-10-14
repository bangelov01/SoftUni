using System;

namespace _24.House_Painting_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            double houseHeightX = double.Parse(Console.ReadLine());
            double sideWallLenghtY = double.Parse(Console.ReadLine());
            double roofTriangleWallHeightH = double.Parse(Console.ReadLine());

            //Walls

            double windowHeight = 1.5;
            double windowLenght = 1.5;
            double doorHeight = 2;
            double doorLenght = 1.2;

            double sideWallArea = (houseHeightX * sideWallLenghtY);
            double windowsArea = windowHeight * windowLenght;
            double bothSides = (2 * sideWallArea) - (2 * windowsArea);
            double backWallArea = houseHeightX * houseHeightX;
            double entranceArea = doorHeight * doorLenght;
            double totalBackAndFrontArea = (2 * backWallArea) - entranceArea;

            double totalArea = bothSides + totalBackAndFrontArea;
            double greenPaintNeeded = totalArea / 3.4;

            //Roof

            double ractangleArea = 2 * (houseHeightX * sideWallLenghtY);
            double triangeArea = 2 * (houseHeightX * roofTriangleWallHeightH / 2);
            double totalRoofArea = ractangleArea + triangeArea;
            double redPaintNeeded = totalRoofArea / 4.3;

            Console.WriteLine($"{greenPaintNeeded:f2}");
            Console.WriteLine($"{redPaintNeeded:f2}");
        }
    }
}
