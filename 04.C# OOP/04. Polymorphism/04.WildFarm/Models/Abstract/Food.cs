﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Abstract
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
