using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Queue<T>
    {
        private readonly LinkedList<T> _container;

        public bool IsEmpty => Size() == 0;
        
        public Queue()
        {
            _container = new LinkedList<T>();
        } 

        public void Enqueue(T item)
        {
            _container.AddFirst(item);
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                return default;
            }

            var value = _container.Last;
            _container.RemoveLast();
            return value.Value;
        }

        public int Size()
        {
            return _container.Count;
        }
    }
}