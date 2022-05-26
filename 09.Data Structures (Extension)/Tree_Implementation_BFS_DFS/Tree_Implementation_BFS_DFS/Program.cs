using Tree_Implementation_BFS_DFS;

using System.Linq;

var child1 = new Tree<int>(5, new Tree<int>[] { new Tree<int>(2), new Tree<int>(6) });
var child2 = new Tree<int>(20, new Tree<int>[] { new Tree<int>(19), new Tree<int>(22) });

var root = new Tree<int>(10, new Tree<int>[] { child1, child2 } );
root.AddChild(6, new Tree<int>(4));
root.AddChild(6, new Tree<int>(8));

var dfsOrder = root.OrderDfs();

var bfsOrder = root.OrderBfs();

Console.WriteLine(string.Join(" ", dfsOrder) + " Count:" + dfsOrder.Count);
Console.WriteLine(string.Join(" ", bfsOrder) + " Count:" + bfsOrder.Count);

root.RemoveNode(22);

Console.WriteLine(root.OrderBfs().Count);
Console.WriteLine(root.OrderDfs().Count);

root.RemoveNode(10);

Console.WriteLine(root.OrderBfs().Count);
Console.WriteLine(root.OrderDfs().Count);
