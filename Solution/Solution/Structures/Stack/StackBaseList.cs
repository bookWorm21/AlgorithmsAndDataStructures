using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class StackBaseList<T>
    {
        private readonly LinkedList<T> _container;

        public StackBaseList()
        {
            _container = new LinkedList<T>();
        } 

        public int Size()
        {
            return _container.Count;
        }

        public T Pop()
        {
            if (Size() == 0)
            {
                return default;
            }

            var value = Peek();
            _container.Remove(_container.First);
            return value;
        }
	  
        public void Push(T val)
        {
            _container.AddFirst(val);
        }

        public T Peek()
        {
            if (Size() == 0)
            {
                return default;
            }

            return _container.First.Value;
        }
    }
}