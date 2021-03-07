using _09.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class AddRemoveCollection : AddCollection, IRemove
    {
        public AddRemoveCollection()
            :base()
        {
        }

        public override int Add(string item)
        {
            this.List.Insert(0, item);

            return 0;
        }

        public virtual string Remove()
        {
            string toRemove = this.List[List.Count - 1];

            this.List.RemoveAt(this.List.Count - 1);

            return toRemove;
        }
    }
}
