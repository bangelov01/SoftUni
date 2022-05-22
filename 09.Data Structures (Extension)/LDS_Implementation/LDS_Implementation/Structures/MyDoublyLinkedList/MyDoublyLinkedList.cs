namespace LDS_Implementation.Structures.MyDoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using LDS_Implementation.Contracts;

    public class MyDoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> last;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new DoublyNode<T>(item, null, null);

            if (!this.IsFirstNode(item, newNode))
            {
                var oldHead = this.head;
                oldHead.Previous = newNode;
                this.head = newNode;
                this.head.Next = oldHead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new DoublyNode<T>(item, null, null);

            if (!this.IsFirstNode(item, newNode))
            {
                var oldLast = this.last;
                oldLast.Next = newNode;

                this.last = newNode;
                this.last.Previous = oldLast;
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

            var item = this.head.Item;

            if (this.head.Equals(this.last))
            {
                this.head = null;
                this.last = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }

            this.Count--;

            return item;
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

                this.last = this.last.Previous;
                this.last.Next = null;
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

        private bool IsFirstNode(T item, DoublyNode<T> newNode)
        {
            var result = false;

            if (this.Count == 0)
            {
                this.head = this.last = newNode;

                result = true;
            }

            return result;
        }

        private void EnsureNotEmpty()
        {
            if (this.Count <= 0 || this.head == null || this.last == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
