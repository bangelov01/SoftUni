namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            if (this.root == null) throw new InvalidOperationException();

            this.root = this.Delete(element, this.root);
        }

        private Node Delete(T element, Node root)
        {
            if (root == null) return root;

            if (element.CompareTo(root.Value) < 0)
            {
                root.Left = this.Delete(element, root.Left);
                return root;
            }
            else if (element.CompareTo(root.Value) > 0)
            {
                root.Right = this.Delete(element, root.Right);
                return root;
            }

            if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }
            else
            {
                var parent = root;

                var successor = root.Right;

                while (successor.Left != null)
                {
                    parent = successor;
                    successor = successor.Left;
                }

                if (parent != root)
                {
                    parent.Left = successor.Right;
                }
                else
                {
                    parent.Right = successor.Right;
                }

                root.Value = successor.Value;

                return root;
            }
        }

        public void DeleteMax()
        {
            if (this.root == null) throw new InvalidOperationException();

            this.root = this.DeleteMax(this.root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null) return node.Left;

            node.Right = this.DeleteMax(node.Right);

            return node;
        }

        public void DeleteMin()
        {
            if (this.root == null) throw new InvalidOperationException();

            this.root = this.DeleteMin(this.root);
        }

        public int Count()
        {
            return this.Count(this.root);
        }

        private int Count(Node node)
        {
            if (node == null) return 0;

            return 1 + this.Count(node.Left) + this.Count(node.Right);
        }

        public int Rank(T element)
        {
            return this.Rank(element, this.root);
        }

        private int Rank(T element, Node node)
        {
            if (node == null) return 0;

            if (element.CompareTo(node.Value) < 0)
            {
                return this.Rank(element, node.Left);
            }

            else if (element.CompareTo(node.Value) > 0)
            {
                return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
            }

            return this.Count(node.Left);

        }

        public T Select(int rank)
        {
            var node = this.Select(this.root, rank);

            if (node == null) throw new InvalidOperationException();

            return node.Value;
        }

        private Node Select(Node node, int rank)
        {
            if (node == null) return null;

            int leftCount = this.Count(node.Left);

            if (leftCount == rank) return node;

            if (leftCount > rank)
            {
                return this.Select(node.Left, rank);
            }
            else
            {
                return this.Select(node.Right, rank - (leftCount + 1));
            }
        }

        public T Ceiling(T element)
        {
            return this.Select(this.Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return this.Select(this.Rank(element) - 1);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            if (!this.Contains(startRange) || !this.Contains(endRange)) throw new InvalidOperationException();

            var resultRange = new List<T>();

            this.EachInOrder(resultRange.Add);

            return resultRange.Where(x => x.CompareTo(startRange) >= 0 && x.CompareTo(endRange) <= 0);
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null) return node.Right;

            node.Left = DeleteMin(node.Left);

            return node;
        }
    }
}
