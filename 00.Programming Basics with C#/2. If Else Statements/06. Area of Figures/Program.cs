using System;

namespace _06._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double sideLenght = double.Parse(Console.ReadLine());
                double area = sideLenght * sideLenght;
                Console.WriteLine($"{area:f3}");
            }
            else if (figure == "rectangle")
            {
                double sideLenghtRec = double.Parse(Console.ReadLine());
                double sideLenghtRec2 = double.Parse(Console.ReadLine());
                double areaRec = sideLenghtRec * sideLenghtRec2;
                Console.WriteLine($"{areaRec:f3}");
            }
            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double areaCircle = Math.PI * (r*r);
                Console.WriteLine($"{areaCircle:f3}");
            }
            else if (figure == "triangle")
            {
                double sideLenghtTri = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double areaTri = (sideLenghtTri / 2) * height;
                Console.WriteLine($"{areaTri:f3}");
            }
        }
    }
}
