using System;
using System.Numerics;

namespace _30.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numberOfSnowballsMade = byte.Parse(Console.ReadLine());
            BigInteger maxValue = int.MinValue;
            short saveSnow = 0;
            short saveTime = 0;
            byte saveQuality = 0;

            for (int i = 0; i < numberOfSnowballsMade; i++)
            {
                short snowballSnow = short.Parse(Console.ReadLine());
                short snowballTime = short.Parse(Console.ReadLine());
                byte snowballQuality = byte.Parse(Console.ReadLine());

                BigInteger value = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (value > maxValue)
                {
                    saveSnow = snowballSnow;
                    saveTime = snowballTime;
                    saveQuality = snowballQuality;
                    maxValue = value;
                }
            }
            Console.WriteLine($"{saveSnow} : {saveTime} = {maxValue} ({saveQuality})");
        }
    }
}
