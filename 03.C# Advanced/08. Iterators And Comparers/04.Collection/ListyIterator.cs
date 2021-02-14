using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
