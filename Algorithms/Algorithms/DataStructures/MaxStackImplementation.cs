using System;

namespace Algorithms
{
    public interface IMaxStackImplementation<T> : IStackImplementation<T>
       where T : IComparable<T>
    {
        T Max();
    }

    public class MaxStackImplementation<T> : IMaxStackImplementation<T>
        where T: IComparable<T>
    {
        private StackImplementation<T> trackingStack;
        private StackImplementation<T> mainStack;

        public MaxStackImplementation(int stackSize)
        { 
            this.trackingStack = new StackImplementation<T>(stackSize);
            this.mainStack = new StackImplementation<T>(stackSize);
        }


        public T Max()
        {
            return trackingStack.Peek();
        }

        public T Pop()
        {
            var pop = this.mainStack.Pop();
            if (pop.CompareTo(this.trackingStack.Peek()) == 0)
            {
                this.trackingStack.Pop();
            }
          
            return pop;
        }

        public void Push(T item)
        {
            if (this.trackingStack.CurrentSize== 0 
                || item.CompareTo(this.trackingStack.Peek()) >= 0)
            {
                this.trackingStack.Push(item);
            }
           
            this.mainStack.Push(item);
        }

        public int CurrentSize
        {
            get
            {
                return this.mainStack.CurrentSize;
            }
        }

        public T Peek()
        {
            return this.mainStack.Peek();
        }
    }
}
