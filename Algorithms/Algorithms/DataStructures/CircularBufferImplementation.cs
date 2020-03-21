using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class CircularBufferImplementation<T>
    {
        private readonly int _size;
        private readonly T[] _buffer;
        private int _index;

        public CircularBufferImplementation(int size)
        {
            _size = size;
            _buffer = new T[_size];
        }

        public void Add(T item)
        {
            _index = (_index + 1) % _size;
            _buffer[_index] = item;
        }

        public IEnumerable<T> GetAll()
        {
            foreach (var item in _buffer)
            {
                yield return item;
            }
        }
    }
}
