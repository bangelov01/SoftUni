
namespace LDS_Implementation.Structures.MyQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using LDS_Implementation.Contracts;

    public class MyQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;

        public MyQueue()
        {
            this.head = new Node<T>();
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            this.EnsureNotEmpty();

            return this.CheckNext(item, this.head);
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            var newHead = this.head.Next;
            var currentItem = this.head.Item;

            this.head = newHead;
            this.Count--;

            return currentItem;
        }

        public void Enqueue(T item)
        {
            if (this.head.Item == null)
            {
                this.head.Item = item;
            }
            else
            {
                this.AddNode(item, this.head);
            }

            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
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
            if (this.Count <= 0 || this.head == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void AddNode(T item, Node<T> node)
        {
            if (node.Next == null)
            {
                node.Next = new Node<T> { Item = item };
                return;
            }
            else
            {
                this.AddNode(item, node.Next);
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