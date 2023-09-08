namespace LDS_Implementation.Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using LDS_Implementation.Contracts;

    public class MyList<T> : IAbstractList<T>
    {
        private const int defaultCapacity = 4;
        private T[] items;

        public MyList(int capacity = defaultCapacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.GrowIfNecessary();
            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            var result = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public int IndexOf(T item) =>
            Array.IndexOf(this.items, item);

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNecessary();

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            var index = this.IndexOf(item);
            var result = false;

            if (index >= 0)
            {
                result = true;
                this.RemoveAt(index);
            }

            return result;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void GrowIfNecessary()
        {
            if (this.Count == this.items.Length)
            {
                this.items = this.Grow();
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private T[] Grow()
        {
            var newArray = new T[this.Count * 2];

            Array.Copy(this.items, newArray, this.items.Length);

            return newArray;
        }
    }
}