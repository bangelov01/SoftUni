namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        public T ExtractMax()
        {
            if (this.elements.Count == 0) throw new InvalidOperationException();

            var firstElement = this.elements[0];

            this.Swap(0, this.elements.Count - 1);

            this.elements.RemoveAt(this.elements.Count - 1);

            this.HeapifyDown(0);

            return firstElement;
        }

        public T Peek() 
            => !this.elements.Any() ? throw new InvalidOperationException() : this.elements[0];

        private void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;

            while (index > 0 && this.elements[index].CompareTo(this.elements[parentIndex]) > 0) 
            { 
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            var biggerChildIndex = GetBiggerChildIndex(index);

            while (biggerChildIndex >= 0 && biggerChildIndex < this.elements.Count && this.elements[biggerChildIndex].CompareTo(this.elements[index]) > 0)
            {
                this.Swap(biggerChildIndex, index);
                index = biggerChildIndex;
                biggerChildIndex = GetBiggerChildIndex(index);
            }

            int GetBiggerChildIndex(int parentIndex)
            {
                var leftChildIndex = parentIndex * 2 + 1;
                var rightChildIndex = parentIndex * 2 + 2;

                if (rightChildIndex < this.elements.Count)
                {
                    if(this.elements[leftChildIndex].CompareTo(this.elements[rightChildIndex]) > 0)
                    {
                        return leftChildIndex;
                    }

                    return rightChildIndex;
                }
                else if (leftChildIndex < this.elements.Count) return leftChildIndex;
                else return -1;
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }
    }
}
