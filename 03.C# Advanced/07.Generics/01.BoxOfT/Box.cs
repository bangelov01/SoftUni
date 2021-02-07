using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
   public class Box<T>
    {
        private const int initialSize = 2;
        private T[] items;

        public Box()
        {
            items = new T[initialSize];
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count] = element;
            Count++;
        }

        public T Remove()
        {
            T save = items[Count - 1];
            items[Count - 1] = default;
            Count--;
            return save;
        }

        private void Resize()
        {
            T[] copy = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }
    }
}
