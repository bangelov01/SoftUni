using _08.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get; }

        public void AddPrivate(IPrivate addPrivate);
    }
}
