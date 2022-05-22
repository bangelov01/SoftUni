namespace LDS_Implementation.Structures.MySinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using LDS_Implementation.Contracts;

    public class MySinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> last;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newHead = new Node<T> { Item = item };
            newHead.Next = this.head;

            if (this.head == null)
            {
                this.last = newHead;
            }

            this.head = newHead;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newLast = new Node<T> { Item = item };

            if (this.last == null)
            {
                this.last = newLast;
                this.head = newLast;
            }
            else
            {
                this.last.Next = newLast;
                this.last = newLast;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            return this.last.Item;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            var oldHead = this.head;
            this.head = this.head.Next;

            if (this.head == null)
            {
                this.last = null;
            }

            this.Count--;
            return oldHead.Item;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            var item = this.last.Item;

            if (this.head.Equals(this.last))
            {
                this.head = null;
                this.last = null;
            }
            else
            {
                item = this.DeleteLast(this.head);
            }

            this.Count--;

            return item;
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

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count <= 0 || this.head == null || this.last == null)
            {
                throw new ArgumentNullException();
            }
        }

        private T DeleteLast(Node<T> node)
        {
            if (node.Next.Equals(this.last))
            {
                this.last = node;

                this.last.Next = null;

                return last.Item;
            }
            else
            {
                return this.DeleteLast(node.Next);
            }
        }
    }
}