using _08.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
