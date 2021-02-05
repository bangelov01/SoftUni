using System;
using System.Collections.Generic;
using System.Text;

namespace _12.CustomList
{
    class CustomList
    {
        private const int initialCapacity = 2;

        private int[] values;

        public CustomList()
        {
            values = new int[initialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return values[index];
            }

            set
            {
                ValidateIndex(index);
                values[index] = value;
            }
        }

        private bool ValidateIndex(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("Invalid Index!");
            }

            return true;
        }

        public void Add(int value)
        {
            if (Count == values.Length)
            {
                Resize();
            }

            values[Count] = value;
            Count++;
        } 

        public int RemoveAt(int index)
        {
            ValidateIndex(index);

            int returnValue = values[index];

            values[index] = default (int);

            Shift(index);

            Count--;

            if (Count <= values.Length/4)
            {
                Shrink();
            }

            return returnValue;
        }

        private void Resize()
        {
            int[] copy = new int[values.Length * 2];

            for (int i = 0; i < values.Length; i++)
            {
                copy[i] = values[i];
            }

            values = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[values.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = values[i];
            }

            values = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                values[i] = values[i + 1];
            }

            values[Count - 1] = 0;
        }

        public void Insert(int index, int value)
        {
            ValidateIndex(index);

            if (Count == values.Length)
            {
                Resize();
            }

            for (int i = Count; i > index; i--)
            {
                values[i] = values[i - 1];
            }

            values[index] = value;
            Count++;
        }

        public bool Contains (int value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (values[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            int holder = values[secondIndex];
            values[secondIndex] = values[firstIndex];
            values[firstIndex] = holder;
        }

        public int Find(Predicate<int> predicate)
        {
            foreach (var item in values)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return 0;
        }

        public int[] Reverse()
        {
            int[] copy = values;
            int i = 0;
            int j = Count - 1;

            while (i < j)
            {
                int temp = copy[i];
                copy[i] = copy[j];
                copy[j] = temp;
                i++;
                j--;
            }

            values = copy;

            return values;
        }
    }
}
