namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString() => this.GetAsStringDfs().TrimEnd();

        public Tree<T> GetDeepestLeftomostNode()
        {
            throw new NotImplementedException();
        }

        public List<T> GetLeafKeys() => this.GetLeafKeysBfs();

        public List<T> GetMiddleKeys() => this.GetMiddleKeysBfs();

        public List<T> GetLongestPath() => this.GetLongestPathDfs(new List<T>());

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }

        private string GetAsStringDfs(int indentation = 0)
        {
            var result = new string(' ', indentation) + this.Key + "\r\n";

            foreach (var child in this.Children)
            {
                result += child.GetAsStringDfs(indentation + 2);
            }

            return result;
        }

        private List<T> GetLeafKeysBfs()
        {
            var leafResult = new List<T>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (!element.children.Any())
                {
                    leafResult.Add(element.Key);
                    continue;
                }

                foreach (var child in element.children)
                {
                    queue.Enqueue(child);
                }
            }

            return leafResult;
        }

        private List<T> GetMiddleKeysBfs()
        {
            var resultMiddleNodes = new List<T>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (element.children.Any() && element.Parent != null)
                {
                    resultMiddleNodes.Add(element.Key);
                }

                foreach (var child in element.children)
                {
                    queue.Enqueue(child);
                }
            }

            return resultMiddleNodes;
        }

        private List<T> GetLongestPathDfs(List<T> nodes, int level = 1)
        {
            if (level > nodes.Count)
            {
                nodes.Add(this.Key);
            }

            foreach (var child in this.Children)
            {
                child.GetLongestPathDfs(nodes, level + 1);
            }

            return nodes;
        }
    }
}
