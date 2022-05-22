using LDS_Implementation.Structures;
using LDS_Implementation.Structures.MyQueue;
using LDS_Implementation.Structures.MySinglyLinkedList;
using LDS_Implementation.Structures.MyStack;

//TEST HERE

var linkedList = new MySinglyLinkedList<string>();

linkedList.AddLast("asd");
Console.WriteLine(linkedList.Count);
linkedList.RemoveFirst();
Console.WriteLine(linkedList.Count);
