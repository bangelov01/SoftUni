﻿using _08.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates { get => privates.AsReadOnly(); }


        public void AddPrivate(IPrivate addPrivate)
        {
            privates.Add(addPrivate);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var @private in privates)
            {
                sb.AppendLine($"  {@private}");
            }

            return sb.ToString().Trim();
        }
    }
}
