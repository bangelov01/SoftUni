using System;

namespace _12._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int cakeSize = cakeWidth * cakeLength;
            int sumPiecesTaken = 0;

            while (cakeSize >= sumPiecesTaken)
            {
                string pieces = Console.ReadLine();
                if (pieces == "STOP")
                {
                    break;
                }
                int convert = int.Parse(pieces);
                sumPiecesTaken += convert;
            }
            if (sumPiecesTaken >= cakeSize)
            {
                sumPiecesTaken -= cakeSize;
                Console.WriteLine($"No more cake left! You need {sumPiecesTaken} pieces more.");
            }
            else
            {
                cakeSize -= sumPiecesTaken;
                Console.WriteLine($"{cakeSize} pieces are left.");
            }
        }
    }
}
