using Algorithms.DataStructures;

namespace Algorithms.Algorithms
{
    public class FindNodeFromEndOfLinkedList<T>
    {
        /// <summary>
        /// Finds the n’th Node from the end of a given linked List
        /// </summary>
        /// <param name="head"></param>
        /// <param name="searchIndex"></param>
        /// <returns></returns>
        public T Find(SinglyLinkedNode<T> head, int searchIndex)
        {
            var currentNode = head;
            var i = 0;
            while (i < searchIndex)
            {
                currentNode = currentNode.Next;
                i++;
            }

            var sec = head;
            while (currentNode != null)
            {
                currentNode = currentNode.Next;
                sec = sec.Next;
            }

            return sec.Data;
        }
    }
}
