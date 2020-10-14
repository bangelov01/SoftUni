using System;

namespace _21.Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {

            int pokePower = int.Parse(Console.ReadLine());
            int pokeDistance = int.Parse(Console.ReadLine());
            byte exhaustFactor = byte.Parse(Console.ReadLine());
            int countPokes = 0;
            long halfValue = pokePower / 2;

            while (pokePower >= pokeDistance)
            {
                pokePower -= pokeDistance;
                countPokes++;

                if (pokePower == halfValue && exhaustFactor > 0)
                {
                     pokePower /= exhaustFactor;
                }

            }
            Console.WriteLine(pokePower);
            Console.WriteLine(countPokes);
        }
    }
}
