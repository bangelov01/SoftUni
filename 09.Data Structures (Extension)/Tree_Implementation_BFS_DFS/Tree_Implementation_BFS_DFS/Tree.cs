namespace Tree_Implementation_BFS_DFS
{
    using System;
    using System.Collections.Generic;

    using Tree_Implementation_BFS_DFS.Contracts;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();
        public bool IsRootDeleted { get; private set; } = false;

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();

            if (IsRootDeleted)
            {
                return result;
            }

            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subTree = queue.Dequeue();

                result.Add(subTree.Value);

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();

            if (IsRootDeleted)
            {
                return result;
            }

            this.DFS(this, result);

            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var searchedNode = this.FindBFS(parentKey);

            if (searchedNode == null)
            {
                throw new NullReferenceException("Invalid Key");
            }

            searchedNode.children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = this.FindBFS(nodeKey);

            if (searchedNode == null)
            {
                throw new NullReferenceException("Invalid Key");
            }

            foreach (var child in searchedNode.Children)
            {
                child.Parent = null;
            }

            searchedNode.children.Clear();

            var searchedParent = searchedNode.Parent;

            if (searchedParent == null)
            {
                this.IsRootDeleted = true;
            }
            else
            {
                searchedParent.children.Remove(searchedNode);
            }

            searchedNode.Value = default(T);
        }

        private void DFS(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.children)
            {
                this.DFS(child, result);
            }

            result.Add(tree.Value);
        }

        private Tree<T> FindBFS(T parentKey)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subTree = queue.Dequeue();

                if (subTree.Value.Equals(parentKey))
                {
                    return subTree;
                }

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
