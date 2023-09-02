namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.Validate(index);
                return this.items[this.Count - index - 1];
            }
            set
            {
                this.Validate(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            ShouldGrow();

            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item)) return true;
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item)) return this.Count - i - 1;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            //if (index < 0 || index > this.Count) throw new IndexOutOfRangeException();
            this.Validate(index);

            ShouldGrow();

            for (int i = this.Count; i >= this.Count - index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[this.Count - index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            var index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    index = i; break;
                }
            }

            if (index != -1)
            {
                for (int i = index; i <= this.Count; i++)
                {
                    this.items[i] = this.items[i + 1];
                }

                this.Count--;
            }

            return index != -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ShouldGrow()
        {
            if (items.Length == this.Count)
            {
                var newArray = new T[this.items.Length * 2];

                for (int i = 0; i < this.items.Length; i++)
                {
                    newArray[i] = this.items[i];
                }

                this.items = newArray;
            }
        }

        private void Validate(int index)
        {
            if (index < 0 || index >= this.Count) throw new IndexOutOfRangeException();
        }
    }
}