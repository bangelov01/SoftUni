using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private string displacement = "n/a";
        private string efficiency = "n/a";
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public Engine(string model, int power, string displacement) : this(model, power)
        {
            Displacement = displacement;
        }

        public Engine(string model, int power, string displacement, string efficiency) : this(model, power, displacement)
        {
            Efficiency = efficiency;
        }
        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }


    }
}
