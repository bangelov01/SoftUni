using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine(int horsePowwer, double cubicCapacity)
        {
            HorsePowwer = horsePowwer;
            CubicCapacity = cubicCapacity;
        }

        public int HorsePowwer { get; set; }
        public double CubicCapacity { get; set; }
    }
}
