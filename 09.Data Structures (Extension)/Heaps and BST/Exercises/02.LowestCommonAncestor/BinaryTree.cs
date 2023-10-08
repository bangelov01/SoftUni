namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            (var firstNode, var secondNode) = this.FindBfs(first, second, this);

            if (firstNode == null || secondNode == null) throw new InvalidOperationException();

            return this.FindAncestors(firstNode).Intersect(this.FindAncestors(secondNode)).First();
        }

        private List<T> FindAncestors(BinaryTree<T> node)
        {
            var result = new List<T>();

            var current = node;

            while (current != null)
            {
                result.Add(current.Value);

                current = current.Parent;
            }

            return result;
        }

        private (BinaryTree<T>, BinaryTree<T>) FindBfs(T firstItem, T secondItem, BinaryTree<T> root)
        {
            BinaryTree<T> firstFoundNode = null;
            BinaryTree<T> secondFoundNode = null;

            var nodeQueue = new Queue<BinaryTree<T>>();
            nodeQueue.Enqueue(root);

            while (nodeQueue.Count > 0)
            {
                var node = nodeQueue.Dequeue();

                if (firstItem.Equals(node.Value))
                {
                    firstFoundNode = node;
                }
                else if (secondItem.Equals(node.Value))
                {
                    secondFoundNode = node;
                }

                if (node.LeftChild != null) nodeQueue.Enqueue(node.LeftChild);

                if (node.RightChild != null) nodeQueue.Enqueue(node.RightChild);
            }

            return (firstFoundNode, secondFoundNode);
        }
    }
}
