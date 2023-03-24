using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Stack<T>
    {
        private readonly List<T> _container;
        
        public Stack()
        {
            _container = new List<T>();
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
            _container.RemoveAt(_container.Count - 1);
            return value;
        }
	  
        public void Push(T val)
        {
            _container.Add(val);
        }

        public T Peek()
        {
            if (Size() == 0)
            {
                return default;
            }

            return _container[_container.Count - 1];
        }
    }
}