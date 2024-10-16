using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExamples.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }
        public bool isHeadNull => Head == null ? true : false;
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }
        public SinglyLinkedList()
        {

        }

        // O(1)
        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        // O(n)
        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        // Araya ekleme
        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null)
                throw new ArgumentNullException();

            if (Head == null)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list.");
        }

        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (refNode == null)
                throw new ArgumentNullException();

            if (Head == null)
            {
                AddFirst(newNode.Value);
                return;
            }

            var current = Head;
            while (current != null)
            {
                if (current.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list.");
        }


        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null)
                throw new ArgumentNullException();

            if (Head == null)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Next.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T RemoveFirst()
        {
            if (isHeadNull)
                throw new Exception("There is nothing to remove.");

            var firstValue = Head.Value;
            Head = Head.Next;
            return firstValue;
        }

        public T RemoveLast()
        {
            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            var lastValue = prev.Next.Value;
            prev.Next = null;
            return lastValue;
        }

        public void Remove(T value)
        {
            if (!isHeadNull)
                throw new Exception("There is nothing to remove.");

            if (value == null)
                throw new ArgumentNullException();

            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            do
            {
                if (current.Value.Equals(value))
                {
                    //son eleman mı ?
                    if (current.Next==null)
                    {
                        //head mi silinmek isteniyor (tek eleman mı)
                        if (prev==null)
                        {
                            Head = null;
                            return;
                        }
                        //son eleman mı silinmek isteniyor
                        else
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else
                    {
                        //head
                        if (prev==null)
                        {
                            Head = Head.Next;
                            return;
                        }
                        //aradan bir eleman
                        else
                        {
                            prev.Next = current.Next;
                            return;
                        }
                    }
                }
                prev = current;
                current = current.Next;
            } while (current!=null);

            throw new ArgumentException("There is nothing to remove that you want.");
        }
    }
}
