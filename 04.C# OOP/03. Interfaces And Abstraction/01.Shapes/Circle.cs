using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; private set; }

        public void Draw()
        {
            double rIn = Radius - 0.4;
            double rOut = Radius + 0.4;

            for (double i = Radius; i >= -Radius; --i)
            {
                for (double k = -Radius; k < rOut; k+=0.5)
                {
                    double value = k * k + i * i;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
