namespace _04.BinarySearchTree
{
    internal class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }
    }
}
