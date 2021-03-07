using _09.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IUsed
    {
        public MyList()
            :base()
        {
        }

        public int Used => this.List.Count;
        public override string Remove()
        {
            string toRemove = this.List[0];

            this.List.RemoveAt(0);

            return toRemove;
        }
    }
}
