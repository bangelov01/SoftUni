namespace LDS_Implementation.Structures.MyQueue
{
    public class Node<T>
    {
        public T Item { get; set; }

        public Node<T> Next { get; set; }
    }
}