using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class CircularLinkedListImplementation<T>
    {
        private long size = 0;
        private SinglyLinkedNode<T> head;
        private SinglyLinkedNode<T> tail;

        public long Size { get { return size; } }

        public void AddAtStart(T item)
        {
            var newNode = new SinglyLinkedNode<T> { Data = item };

            if (size == 0)
            {
                head = newNode;
                tail = newNode;
                newNode.Next = head;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
                tail.Next = head;
            }
            size++;
        }

        public void AddAtEnd(T item)
        {
            var newNode = new SinglyLinkedNode<T> { Data = item };
            if (size == 0)
            {
                head = newNode;
                tail = newNode;
                newNode.Next = head;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
                newNode.Next = head;
            }
            size++;
        }

        public T TakeAtEnd()
        {
            T value = tail.Data;
            var currentNode = head;
            do
            {
                currentNode = currentNode.Next;           
            } while (currentNode.Next.Next != head);

            currentNode.Next = head;
            tail = currentNode;
            size--;
            return value;
        }

        public T TakeAtStart()
        {
            var value = head.Data;

            head = head.Next;
            tail.Next = head;
            size--;
            return value;
        }

        public IEnumerable<T> GetAll()
        {
            var currentNode = head;

            do
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
            while (currentNode != head);
        }
    }
}
