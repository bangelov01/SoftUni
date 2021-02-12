using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _05.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private T[] items;
        private int initialSize = 4;

        public MyStack()
        {
            items = new T[initialSize];
        }

        public int Count { get; private set; }

        public void Push(T elment)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = elment;
            Count++;
        }

        public T Pop()
        {
            T elementToReturn = items[Count - 1];
            items[Count - 1] = default;
            Count--;
            return elementToReturn;
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

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
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
