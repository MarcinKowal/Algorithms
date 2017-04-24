using Algorithms.DataStructures;
using System;

namespace Algorithms.Algorithms
{
    public class MergeTwoSinglyLinkedLists
    {
        public SinglyLinkedListImplementation<T> Merge<T>(SinglyLinkedNode<T> headOfFirstList, SinglyLinkedNode<T> headOfSecondList)
            where T: IComparable<T>
        {
            var resultList = new SinglyLinkedListImplementation<T>();

            var firstPointer = headOfFirstList;
            var secondPointer = headOfSecondList;

            while (firstPointer != null && secondPointer != null)
            {
                if (firstPointer.Data.CompareTo(secondPointer.Data) < 0)
                {
                    resultList.AddAtEnd(firstPointer.Data);
                    firstPointer = firstPointer.Next;
                }
                else
                {
                    resultList.AddAtEnd(secondPointer.Data);
                    secondPointer = secondPointer.Next;
                }
            }

            while(firstPointer != null)
            {
                resultList.AddAtEnd(firstPointer.Data);
                firstPointer = firstPointer.Next;
            }

            while(secondPointer != null)
            {
                resultList.AddAtEnd(secondPointer.Data);
                secondPointer = secondPointer.Next;
            }
            return resultList;
        }
    }
}
