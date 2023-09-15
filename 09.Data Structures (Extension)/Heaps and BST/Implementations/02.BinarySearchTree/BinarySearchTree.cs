namespace _02.BinarySearchTree
{
    using _04.BinarySearchTree;
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node<T> node)
        {
            // Keep from inserting a larger element in sub-trees than upper roots
            // and breaking tree structure.
            this.PreOrderCopy(node);
        }

        public bool Contains(T element) => this.FindNode(element) != null;

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.FindNode(element);

            if (node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }

        private void EachInOrder(Action<T> action, Node<T> node)
        {
            if (node == null) return;

            this.EachInOrder(action, node.LeftChild);

            action(node.Value);

            this.EachInOrder(action, node.RightChild);
        }

        private Node<T> Insert(T element, Node<T> node)
        {
            if (node == null) node = new Node<T>(element);

            else if (element.CompareTo(node.Value) < 0) 
            node.LeftChild = this.Insert(element, node.LeftChild);

            else if (element.CompareTo(node.Value) > 0)
            node.RightChild = this.Insert(element, node.RightChild);

            return node;
        }

        private Node<T> FindNode(T element)
        {
            var node = this.root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0) node = node.LeftChild;

                else if (element.CompareTo(node.Value) > 0) node = node.RightChild;

                else break;
            }

            return node;
        }

        private void PreOrderCopy(Node<T> node)
        {
            if (node == null) return;
            this.Insert(node.Value);
            this.PreOrderCopy(node.LeftChild);
            this.PreOrderCopy(node.RightChild);
        }
    }
}
