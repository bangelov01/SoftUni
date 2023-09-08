namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node<T> { Item = item, Next = null, Previous = null };
                this.Count++;
                return;
            }

            var newNode = new Node<T> { Item = item, Next = this.head, Previous = null };

            this.head.Previous = newNode;
            this.head = newNode;

            this.Count++;
        }

        public void AddLast(T item)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node<T> { Item = item, Next = null, Previous = null };
                this.Count++;
                return;
            }

            var newNode = new Node<T> { Item = item, Next = null, Previous = this.tail };

            this.tail.Next = newNode;
            this.tail = newNode;

            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0) throw new InvalidOperationException();

            return head.Item;
        }

        public T GetLast()
        {
            if (this.Count == 0) throw new InvalidOperationException();

            return tail.Item;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0) throw new InvalidOperationException();

            var oldHead = this.head;
            this.head = this.head.Next;
            this.Count--;

            return oldHead.Item;
        }

        public T RemoveLast()
        {
            if (this.Count == 0) throw new InvalidOperationException();

            var oldTail = this.tail;
            this.tail = this.tail.Previous;
            this.Count--;

            return oldTail.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}