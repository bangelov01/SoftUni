using _09.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public abstract class Collection : IAdd
    {
        private List<string> list;

        protected Collection()
        {
            this.list = new List<string>();
        }

        protected List<string> List { get => this.list; }

        public abstract int Add(string item);
    }
}
