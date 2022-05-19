namespace LDS_Implementation.Structures.MyStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using LDS_Implementation.Contracts;

    public class MyStack<T> : IAbstractStack<T>
    {
        private Node<T> top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            this.EnsureNotEmpty();

            return this.CheckNext(item, this.top);
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.top.Item;
        }

        public T Pop()
        {
            this.EnsureNotEmpty();

            var currentTopItem = this.top.Item;

            var newTop = this.top.Next;

            this.top.Next = null;

            this.top = newTop;
            this.Count--;

            return currentTopItem;
        }

        public void Push(T item)
        {
            var newNode = new Node<T>
            {
                Item = item,
                Next = this.top
            };

            this.top = newNode;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.top;

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
            if (this.Count <= 0 || this.top == null)
            {
                throw new ArgumentNullException();
            }
        }

        private bool CheckNext(T item, Node<T> node)
        {
            if (node != null)
            {
                if (node.Item.Equals(item))
                {
                    return true;
                }

                return this.CheckNext(item, node.Next);
            }

            return false;
        }
    }
}