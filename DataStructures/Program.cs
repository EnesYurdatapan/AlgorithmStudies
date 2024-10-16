#region DynamicArray

////Array > fixed size needed
//// We cannot add or remove items
//using System.Collections;

//char[] arrChar = new char[] { 'b', 't', 'k' };





////ArrayList - not type safe
////10 -> boxing -> object
////b-> boxing -> object
////object-> unboxing -> int
////this kind of boxing-unboxing process can be reason of performance losing

//var arrObj = new ArrayList();
//arrObj.Add(10);
//arrObj.Add('b');


//// List<T>
//// Type safe and dont need to boxing-unboxing

//var arrInt = new List<int>();
//arrInt.Add(1);

//var x = new int[] {1,2,3,4};
//foreach (var item in x)
//{
//    Console.WriteLine(item);
//}

#endregion


#region SinglyLinkedList

using DataStructuresExamples.LinkedList.SinglyLinkedList;

var linkedList = new SinglyLinkedList<int>();
linkedList.AddFirst(1);
linkedList.AddFirst(2);
linkedList.AddFirst(3);


linkedList.AddLast(4);
linkedList.AddLast(5);

var newNode = new SinglyLinkedListNode<int>(33);

linkedList.AddBefore(linkedList.Head.Next, 15);

Console.ReadKey();

#endregion