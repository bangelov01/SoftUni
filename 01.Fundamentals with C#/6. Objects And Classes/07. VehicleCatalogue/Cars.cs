using System;
using System.Collections.Generic;
using System.Text;

namespace _07._VehicleCatalogue
{
    class Cars
    {
        public Cars(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
}
