using System;
using System.Collections.Generic;
using System.Text;

namespace _09._NeedForSpeed
{
    class CarInfo
    {
        public CarInfo(int mileage, int fuel)
        {
            Mileage = mileage;
            Fuel = fuel;
        }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
