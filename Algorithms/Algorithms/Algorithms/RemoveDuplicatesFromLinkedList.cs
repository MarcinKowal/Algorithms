using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms
{
    public class RemoveDuplicatesFromLinkedList
    {
        public SinglyLinkedNode<T> RemoveDuplicates<T>(SinglyLinkedNode<T> headOfList)
        {
            if (headOfList == null)
            {
                throw new ArgumentNullException(nameof(headOfList));
            }

            var dict = new Dictionary<T, int>();

            var prev = headOfList;
            var current = headOfList.Next;

            dict.Add(prev.Data, 1);
            while (current != null)
            {
                if (dict.ContainsKey(current.Data))
                {
                    prev.Next = current.Next; //removing node 
                }
                else
                {
                    dict.Add(current.Data, 1);
                    prev = current;
                }
                current = current.Next;
            }
            return headOfList;
        }
    }
}
