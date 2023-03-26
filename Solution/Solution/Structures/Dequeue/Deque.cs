using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Deque<T>
    {
        private readonly LinkedList<T> _container;

        public bool IsEmpty => _container.Count == 0;
        
        public Deque()
        {
            _container = new LinkedList<T>();
        }

        public Deque(params T[] values) : this()
        {
            foreach (var value in values)
            {
                AddTail(value);
            }
        }

        public static bool operator ==(Deque<T> first, Deque<T> second)
        {
            bool firstIsNull = Equals(first, null);
            bool secondIsNull = Equals(second, null);
            
            if (firstIsNull && secondIsNull)
            {
                return true;
            }

            if (firstIsNull || secondIsNull)
            {
                return false;
            }

            if (first.Size() != second.Size())
            {
                return false;
            }


            var firstIterator = first.ForwardEnumerable().GetEnumerator();
            var secondIterator = second.ForwardEnumerable().GetEnumerator();
            while (firstIterator.MoveNext() && secondIterator.MoveNext())
            {
                if (!Equals(firstIterator.Current, secondIterator.Current))
                {
                    return false;
                }
            }

            return true;
        }
        

        public static bool operator !=(Deque<T> first, Deque<T> second)
        {
            return !(first == second);
        }
        
        protected bool Equals(Deque<T> other)
        {
            return Equals(_container, other._container);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;
            if (ReferenceEquals(this, obj)) 
                return true;
            if (obj.GetType() != GetType()) 
                return false;
            
            return Equals((Deque<T>) obj);
        }

        public override int GetHashCode()
        {
            return _container != null ? _container.GetHashCode() : 0;
        }

        public IEnumerable<T> ForwardEnumerable()
        {
            return _container;
        }

        public IEnumerable<T> BackEnumerable()
        {
            var tail = _container.Last;
            while (tail != null)
            {
                yield return tail.Value;
                tail = tail.Previous;
            }
        }

        public void AddFront(T item)
        {
            _container.AddFirst(item);
        }

        public void AddTail(T item)
        {
            _container.AddLast(item);
        }

        public T RemoveFront()
        {
            if (IsEmpty)
            {
                return default;
            }

            var front = _container.First;
            _container.RemoveFirst();
            return front.Value;
        }

        public T RemoveTail()
        {
            if (IsEmpty)
            {
                return default;
            }

            var back = _container.Last;
            _container.RemoveLast();
            return back.Value;
        }
        
        public int Size()
        {
            return _container.Count;
        }
    }
}