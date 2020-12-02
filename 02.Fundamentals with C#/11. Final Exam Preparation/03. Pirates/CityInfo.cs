using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Pirates
{
    class CityInfo
    {
        public CityInfo(int population, int gold)
        {
            Population = population;
            Gold = gold;
        }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
