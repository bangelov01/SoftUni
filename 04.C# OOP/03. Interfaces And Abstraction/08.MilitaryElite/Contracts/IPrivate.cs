using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
    public interface IPrivate : ISoldier
    {
        public decimal Salary { get; }
    }
}
