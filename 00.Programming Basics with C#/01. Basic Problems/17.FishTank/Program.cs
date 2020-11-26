using System;

namespace _17.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenghtCm = int.Parse(Console.ReadLine());
            int widthCm = int.Parse(Console.ReadLine());
            int heightCm = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());
            double percentageConvert = percentage / 100;

            double aquariumSpace = lenghtCm * widthCm * heightCm;
            double litresTotal = aquariumSpace * 0.001;

            double litresNeeded = litresTotal * (1 - percentageConvert);

            Console.WriteLine(litresNeeded);


        }
    }
}
