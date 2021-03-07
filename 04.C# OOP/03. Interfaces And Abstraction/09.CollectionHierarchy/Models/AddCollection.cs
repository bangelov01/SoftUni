using _09.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class AddCollection : Collection
    {
        public AddCollection()
            : base()
        {
        }

        public override int Add(string item)
        {
            this.List.Add(item);

            return this.List.Count - 1;
        }
    }
}
