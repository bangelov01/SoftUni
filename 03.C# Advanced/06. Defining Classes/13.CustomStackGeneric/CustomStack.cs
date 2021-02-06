using System;
using System.Collections.Generic;
using System.Text;

namespace _13.CustomStackGeneric
{
    public class CustomStack <T>
    {
        private T[] items;
        private const int initialCapacity = 4;

        public CustomStack()
        {
            items = new T[initialCapacity];
        }
        public int Count { get; private set; }

        public void Push(T item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;
            Count++;
        }

        public T Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            int lastIndex = Count - 1;
            T last = items[lastIndex];
            items[lastIndex] = default;
            Count--;
            return last;
        }

        public T Peek()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            int lastIndex = Count - 1;
            T last = items[lastIndex];
            return last;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(items[i]);
            }
        }
        private void Resize()
        {
            T[] copy = new T[initialCapacity * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }
    }
}
