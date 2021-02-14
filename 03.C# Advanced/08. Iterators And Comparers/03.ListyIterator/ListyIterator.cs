using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int index = 0;

        public ListyIterator(params T[] items)
        {
            this.items = new List<T>(items);
        }
        public bool Move()
        {
            if (index == items.Count - 1)
            {
                return false;
            }
            index++;
            return true;
        }

        public bool HasNext()
        {
            if (index == items.Count - 1)
            {
                return false;
            }

            return true;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(items[index]);
            }
            catch
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
}
