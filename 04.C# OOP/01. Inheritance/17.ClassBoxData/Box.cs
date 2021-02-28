using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ClassBoxData
{
    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        public Box(decimal length, decimal width, decimal height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public decimal Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public decimal Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public void CalculateSurfaceArea()
        {
            decimal calc = 2 * (length * width) + 2 * (length * height) + 2 * (width * height);

            Console.WriteLine($"Surface Area - {calc:f2}");
        }

        public void CalculateLateralSurfaceArea()
        {
            decimal calc = 2 * (length * height) + 2 * (width * height);
            Console.WriteLine($"Lateral Surface Area - {calc:f2}");
        }

        public void CalculateVolume()
        {
            decimal calc = length * width * height;
            Console.WriteLine($"Volume - {calc:f2}");
        }
    }
}
