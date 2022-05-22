using LDS_Implementation.Structures;
using LDS_Implementation.Structures.MyDoublyLinkedList;
using LDS_Implementation.Structures.MyQueue;
using LDS_Implementation.Structures.MySinglyLinkedList;
using LDS_Implementation.Structures.MyStack;

//TEST HERE

var linkedList = new MyDoublyLinkedList<string>();

linkedList.AddFirst("asd");
linkedList.AddFirst("dsf");
linkedList.AddFirst("zdf");
linkedList.RemoveFirst();
linkedList.RemoveLast();
Console.WriteLine(linkedList.Count);

