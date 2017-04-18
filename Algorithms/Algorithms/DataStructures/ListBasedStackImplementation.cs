using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public interface IStackImplementation<T>
    {
        T Pop();
        void Push(T item);
        int CurrentSize { get; }
        T Peek();
    }

    public class ListBasedStackImplementation<T> : IStackImplementation<T>
    {
        private int size;
        private int stackPointer = -1;
        private List<T> stack;

        public ListBasedStackImplementation(int stackSize)
        {
            if (stackSize <= 0)
            {
                throw new ArgumentException("Positive size is required");
            }

            this.size = stackSize;
            stack = new List<T>(this.size);
        }

        public T Pop()
        {
            if (this.stackPointer < 0)
            {
                throw new InvalidOperationException("stack is empty");
            }

            var item = this.stack.ElementAt(this.stackPointer);
            this.stackPointer--;
            return item;
        }

        public void Push(T item)
        {
            if (++this.stackPointer == this.size)
            {
                throw new StackOverflowException();
            }

            stack.Insert(this.stackPointer, item);
        }

        public int CurrentSize
        {
            get
            {
                return stackPointer + 1;
            }
        }

        public T Peek()
        {
            if (this.stackPointer < 0)
            {
                throw new InvalidOperationException("stack is empty");
            }
            return this.stack.ElementAt(this.stackPointer);
        }
    }
}
