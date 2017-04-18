using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class LinkedListBasedStackImplementation<T> : IStackImplementation<T>
    {
        private int size = 0;
        private SinglyLinkedNode<T> head;

        public int CurrentSize { get { return size; } }

        public T Peek()
        {
            return head.Data;
        }

        public T Pop()
        {
            var value = head.Data;
            head = head.Next;

            size--;
            return value;
        }

        public void Push(T item)
        {
            var newNode = new SinglyLinkedNode<T> { Data = item, Next = head };
            head = newNode;

            size++;
        }

        public ICollection GetAll()
        {
            if (head != null)
            {
                var all = new List<T>(size);
                var currentNode = head;
                do
                {
                    all.Add(currentNode.Data);
                    currentNode = currentNode.Next;
                }
                while (currentNode != null);

                return all;
            }
            return null;
        }
    }
}
