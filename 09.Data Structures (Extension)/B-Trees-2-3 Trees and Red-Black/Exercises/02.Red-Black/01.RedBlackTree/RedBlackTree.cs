namespace _01.RedBlackTree
{
    using System;

    public class RedBlackTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;

        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Color { get; set; }
        }

        public Node root;

        public RedBlackTree()
        {

        }

        private RedBlackTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public RedBlackTree<T> Search(T element)
        {
            Node current = this.FindNode(element);

            return new RedBlackTree<T>(current);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(this.root, element);
            this.root.Color = Black;
        }

        private Node Insert(Node node, T element)
        {
            if (node == null) {
                return new Node(element);
            }

            if (IsLesser(element, node.Value)) {
                node.Left = this.Insert(node.Left, element);
            }
            else {
                node.Right = this.Insert(node.Right, element);
            }

            // Rotation combinations:
            // Left rotation -> Right rotation (possible)
            // Right rotation -> Left rotation (never)

            if (IsRed(node.Right)) {

                node = this.RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left)) {

                node = this.RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right)) {
                
                this.FlipColors(node);
            }

            return node;
        }

        public void Delete(T key)
        {
            throw new NotImplementedException();
        }

        public void DeleteMin()
        {
            throw new NotImplementedException();
        }

        public void DeleteMax()
        {
            throw new NotImplementedException();
        }

        public int Count() => this.Count(this.root);

        private int Count(Node node)
        {
            if (node == null) return 0;

            return 1 + this.Count(node.Left) + this.Count(node.Right);
        }

        private bool IsLesser(T a, T b) => a.CompareTo(b) < 0;

        private bool AreEqual(T a, T b) => a.CompareTo(b) == 0;

        private void FlipColors(Node node) {
            
            node.Color = !node.Color;
            node.Left.Color = !node.Left.Color;
            node.Right.Color = !node.Right.Color;
        }

        private bool IsRed(Node node) {

            if (node == null) {
                return false;
            }

            return node.Color == Red;
        }

        private Node RotateRight(Node node) {

            // Case when the node to rotate (node.Left) has a right child.
            // When rotated, it should become the left child of the rotated node (node.Left)'s right child.
            // This example shows only the rotation, colors are unbalanced.
            //          12b                         5b
            //      5r       15b    ------>     3r        12r
            //  3r       8b                         8b       15b

            var tempNode = node.Left;
            node.Left = tempNode.Right;
            tempNode.Right = node;

            tempNode.Color = tempNode.Right.Color;
            tempNode.Right.Color = Red;

            return tempNode;
        }

        private Node RotateLeft(Node node) {

            var tempNode = node.Right;
            node.Right = tempNode.Left;
            tempNode.Left = node;

            tempNode.Color = tempNode.Left.Color;
            tempNode.Left.Color = Red;

            return tempNode;
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

        private void PreOrderCopy(Node node)
        {
            if (node == null) {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node FindNode(T element)
        {
            var current = this.root;

            while (current != null) {

                if (IsLesser(element, current.Value)) {
                    current = current.Left;
                }
                else if (IsLesser(current.Value, element)){
                    current = current.Right;
                }
                else {
                    break;
                }
            }

            return current;
        }
    }
}