using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set;}
    }
    public class LinkedListImplementation<T>
    {
        private Node<T> head = null;
        private long size = 0;

        public void AddAtStart(T value)
        {
            head = new Node<T> { Data = value, Next = head }; 
            size++;
        }

        public void AddAtEnd(T value)
        {
            var node = new Node<T> { Data = value, Next = null };

            if (head == null)
            {
                head = node;
            }
            else
            {
                var currentNode = head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = node;
            }

            size++;
        }

        public T GetElementByIndex(long index)
        {
            if (index >= size || index < 0)
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

        public long Size
        {
            get { return size; }
        }

        public T TakeAtStart()
        {
            if (size > 0)
            {
                var nextAfterHead = head.Next;
                var value = head.Data;
                head = nextAfterHead;
                size--;

                return value;
            }
            return default(T);
        }

        public T TakeAtEnd()
        {
            T value;
            //find one before last node
            var currentNode = head;

            if (currentNode.Next != null)
            {
                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                value = currentNode.Next.Data;
                currentNode.Next = null;
            }
            else
            {
                value = currentNode.Data;
            }
            size--;
            return value;
        }

        public void InsertAt(T value, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            var currentNode = head;

            for (int i = 0; i < index - 1; i++)
            {
                currentNode = currentNode.Next;
            }

            var temp = currentNode.Next;
            currentNode.Next = new Node<T> { Data = value, Next = temp };
            size++;
        }

        public IEnumerable<T> GetAll()
        {
            var allItems = new List<T>();

            if (head != null)
            {
                var currentNode = head;
                while (currentNode.Next != null)
                {
                    allItems.Add(currentNode.Data);
                    currentNode = currentNode.Next;
                }

                allItems.Add(currentNode.Data);
            }
            return allItems;
        }
    }
}
