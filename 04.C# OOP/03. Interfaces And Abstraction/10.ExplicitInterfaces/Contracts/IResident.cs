﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces.Contracts
{
    public interface IResident
    {
        public string Name { get; }
        public string Country { get; }

        public string GetName();
    }
}
