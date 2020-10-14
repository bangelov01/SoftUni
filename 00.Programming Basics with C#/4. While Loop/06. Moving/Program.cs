using System;

namespace _06._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int freeSpaceWidth = int.Parse(Console.ReadLine());
            int freeSpaceLength = int.Parse(Console.ReadLine());
            int freeSpaceHeight = int.Parse(Console.ReadLine());
            string numberOfBoxesToMove = Console.ReadLine();

            int totalSpaceHome = freeSpaceWidth * freeSpaceLength * freeSpaceHeight;
            int totalSpaceBoxes = 0;

            while (numberOfBoxesToMove != "Done")
            {
                int boxes = int.Parse(numberOfBoxesToMove);
                totalSpaceBoxes += boxes;
                if (totalSpaceBoxes >= totalSpaceHome)
                {
                    Console.WriteLine($"No more free space! You need {totalSpaceBoxes - totalSpaceHome} Cubic meters more.");
                    break;
                }
                numberOfBoxesToMove = Console.ReadLine();
            }
            if (numberOfBoxesToMove == "Done") Console.WriteLine($"{totalSpaceHome - totalSpaceBoxes} Cubic meters left.");
        }
    }
}
