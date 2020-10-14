using System;

namespace _28._Beer_Keg
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            string saveBarrel = string.Empty;
            double maxValue = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                string name = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > maxValue)
                {
                    maxValue = volume;
                    saveBarrel = name;
                }
            }
            Console.WriteLine(saveBarrel);
        }
    }
}
