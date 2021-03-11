﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Abstract
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, HashSet<string> allowedFoods, double weightModifier,string livingRegion) : base(name, weight, allowedFoods, weightModifier)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
    }
}
