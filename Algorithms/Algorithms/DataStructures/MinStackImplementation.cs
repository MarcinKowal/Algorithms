using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public interface IMinStackImplementation<T> : IStackImplementation<T>
       where T : IComparable<T>
    {
        T Min();
    }

    public class MinStackImplementation<T> : IMinStackImplementation<T>
        where T : IComparable<T>
    {
        private ListBasedStackImplementation<T> mainStack;
        private ListBasedStackImplementation<T> trackingStack;

        public MinStackImplementation(int stackSize)
        {
            this.mainStack = new ListBasedStackImplementation<T>(stackSize);
            this.trackingStack = new ListBasedStackImplementation<T>(stackSize);
        }

        public int CurrentSize
        {
            get
            {
                return this.mainStack.CurrentSize;
            }
        }

        public T Min()
        {
            return this.trackingStack.Peek();
        }

        public T Peek()
        {
            return this.mainStack.Peek();
        }

        public T Pop()
        {
            var item = this.mainStack.Pop();
            if (item.CompareTo(this.trackingStack.Peek()) == 0)
            {
                this.trackingStack.Pop();
            }

            return item;
        }

        public void Push(T item)
        {
            if (this.trackingStack.CurrentSize== 0 
                || item.CompareTo(this.trackingStack.Peek()) <= 0)
            {
                this.trackingStack.Push(item);
            }
            
            this.mainStack.Push(item);
           
        }
    }
}
