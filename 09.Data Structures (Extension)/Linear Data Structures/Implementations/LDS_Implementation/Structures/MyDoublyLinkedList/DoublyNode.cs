namespace LDS_Implementation.Structures.MyDoublyLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DoublyNode<T>
    {
        public DoublyNode()
        {

        }

        public DoublyNode(T item,
            DoublyNode<T> previous,
            DoublyNode<T> next)
        {
            this.Item = item;
            this.Previous = previous;
            this.Next = next;
        }

        public T Item { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
}
