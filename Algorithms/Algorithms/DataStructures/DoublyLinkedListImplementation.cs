using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class DoublyLinkedNode<T>
    {
        public T Data { get; set; }
        public DoublyLinkedNode<T> Prev { get; set; }
        public DoublyLinkedNode<T> Next { get; set; }
    }

    public class DoublyLinkedListImplementation<T>
    {
        private long size = 0; 
        private DoublyLinkedNode<T> head;

        public long Size { get { return this.size; } }

        public void AddAtStart(T item)
        {
            var newNode = new DoublyLinkedNode<T> { Data = item, Prev = null, Next = head };
            if (head != null)
                head.Prev = newNode;
            head = newNode;
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
            var currentNode = head;

            if (currentNode != null)
            {
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                var newNode = new DoublyLinkedNode<T> { Data = item, Next = null, Prev = currentNode };
                currentNode.Next = newNode;
            }
            else
            {
                head = new DoublyLinkedNode<T> { Data = item, Next = null, Prev = null };
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
            T value;
            var currentNode = head;
            if (currentNode == null)
            {
                return default(T);
            }

            if (currentNode.Next != null)
            {
                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;
                }

               value = currentNode.Next.Data;
                currentNode.Next = null;
                size--;
                return value;
            }
            value = currentNode.Data;
            size--;
            return value;

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
    }
}
