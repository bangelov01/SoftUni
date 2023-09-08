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
            int deepestLevel = 1;
            Tree<T> deepestNode = null;
            return GetDeepestLeftomostNodeDfs(ref deepestNode, ref deepestLevel);
        }

        public List<T> GetLeafKeys() => this.GetLeafKeysBfs();

        public List<T> GetMiddleKeys() => this.GetMiddleKeysBfs();

        public List<T> GetLongestPath() => this.GetLongestPathDfs(new List<T>());

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            //var leafNodes = this.GetLeafNodesBfs();

            //var resultList = new List<List<T>>();

            //foreach ( var leaf in leafNodes )
            //{
            //    var node = leaf;
            //    int pathSum = 0;
            //    var currentNodes = new List<T>();

            //    while (node != null)
            //    {
            //        pathSum += Convert.ToInt32(node.Key);
            //        currentNodes.Add(node.Key);
            //        node = node.Parent;
            //    }

            //    if (pathSum == sum)
            //    {
            //        currentNodes.Reverse();
            //        resultList.Add(currentNodes);
            //    }
            //}

            //return resultList;

            int currentSum = Convert.ToInt32(this.Key);
            var allPaths = new List<List<T>>();
            var currentPathsValues = new List<T> { this.Key };

            this.PathsWithGivenSumDfsExample(ref currentSum, sum, allPaths, currentPathsValues);

            return allPaths;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var roots = new List<Tree<T>>();

            SubTreesWithGivenSumDfs(sum, roots);

            return roots;
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

        private List<Tree<T>> GetLeafNodesBfs()
        {
            var leafResult = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (!element.children.Any())
                {
                    leafResult.Add(element);
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

        private Tree<T> GetDeepestLeftomostNodeDfs(ref Tree<T> deepestNode, ref int deepestLevel, int level = 1)
        {
            if (level > deepestLevel && !this.Children.Any())
            {
                deepestLevel = level;
                deepestNode = this;
            }

            foreach(var child in this.Children)
            {
                child.GetDeepestLeftomostNodeDfs(ref deepestNode, ref deepestLevel, level + 1);
            }

            return deepestNode;
        }

        private void PathsWithGivenSumDfsExample(ref int currentSum, int targetSum, List<List<T>> allPaths, List<T> currentPathValues)
        {
            foreach (var child in this.Children)
            {
                currentPathValues.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);
                child.PathsWithGivenSumDfsExample(ref currentSum, targetSum, allPaths, currentPathValues);
            }

            if (currentSum == targetSum)
            {
                allPaths.Add(new List<T>(currentPathValues));
            }

            currentSum -= Convert.ToInt32(this.Key);
            currentPathValues.RemoveAt(currentPathValues.Count - 1);
        }

        private int SubTreesWithGivenSumDfs(int targetSum, List<Tree<T>> roots)
        {
            var currentSum = Convert.ToInt32(this.Key);

            foreach (var child in this.Children)
            {
                currentSum += child.SubTreesWithGivenSumDfs(targetSum, roots);
            }

            if (currentSum == targetSum)
            {
                roots.Add(this);
            }

            return currentSum;
        }
    }
}
