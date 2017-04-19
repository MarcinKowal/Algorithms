using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class DoublyLinkedNode<T>
        where T:IComparable<T>
    {
        public T Data { get; set; }
        public DoublyLinkedNode<T> Prev { get; set; }
        public DoublyLinkedNode<T> Next { get; set; }
    }

    public class DoublyLinkedListImplementation<T>
         where T : IComparable<T>
    {
        private long size = 0; 
        private DoublyLinkedNode<T> head;
        private DoublyLinkedNode<T> tail;

        public long Size { get { return this.size; } }

        public void AddAtStart(T item)
        {
            var newNode = new DoublyLinkedNode<T> { Data = item, Prev = null, Next = head };

            if (size == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                head.Prev = newNode;
                head = newNode;
            }
            size++;
        }

        public T GetElementByIndex(long index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            var currentNode = head;
            var i = 0;
            while (i <= index - 1)
            {
                currentNode = currentNode.Next;
                i++;
            }

            return currentNode.Data;
        }

        public void AddAtEnd(T item)
        {
            var newNode = new DoublyLinkedNode<T> { Data = item, Next = null, Prev = tail };

            if (size == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
           
            size++;
        }

        public T TakeAtStart()
        {
            if (size > 0)
            {
                var value = head.Data;
                head = head.Next;
                size--;
                return value;
            }
            return default(T);
        }

        public T TakeAtEnd()
        {
            if (size > 0)
            {
                var value = tail.Data;
                tail = tail.Prev;
                if (tail != null)
                {
                    tail.Next = null;
                }

                size--;
                return value;
            }
            return default(T);

        }

        public ICollection<T> GetAll()
        {
            var list = new List<T>();
            if (head == null)
                return list;

            var currentNode = head;
            do
            {
                list.Add(currentNode.Data);
                currentNode = currentNode.Next;
            }
            while (currentNode != null);
            return list;
        }

        public void InsertAt(int insertionIndex, T element)
        {
            if (insertionIndex >= size || insertionIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var currentNode = head;

            for (int i = 0; i < insertionIndex - 1; i++)
            {
                currentNode = currentNode.Next;
            }
            var afterNode = currentNode.Next;

            var newNode = new DoublyLinkedNode<T> { Data = element, Prev = currentNode, Next = afterNode };
            currentNode.Next = newNode;
            afterNode.Prev = newNode;
            size++;
        }

        public void Reverse()
        {
            var current = head;
            DoublyLinkedNode<T> temp = null;
            while (current != null)
            {
                temp = current.Prev;
                current.Prev = current.Next;
                current.Next = temp;
                current = current.Prev;
            }
            tail = head;
            head = temp.Prev;
        }

        public int FindItem(T item)
        {
            var index = 0;

            var currentNode = head;
            while(currentNode != null)
            {
                if (item.CompareTo(currentNode.Data) == 0)
                {
                    return index;
                }
                currentNode = currentNode.Next;
                index++;
            }

            return -1;
        }
    }
}
