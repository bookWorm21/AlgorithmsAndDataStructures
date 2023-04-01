using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet<T>
    {
        public int capacity;

        private int _size;
        private List<LinkedList<T>> _entriesContainer; 
        
        public PowerSet()
        {
            capacity = 20000;
            _size = 0;
            
            _entriesContainer = new List<LinkedList<T>>(capacity);
            for (int i = 0; i < capacity; ++i)
            {
                _entriesContainer.Add(new LinkedList<T>());
            }
        }

        public PowerSet(params T[] values) : this()
        {
            for (int i = 0; i < values.Length; ++i)
            {
                Put(values[i]);
            }
        }

        public IEnumerable<T> GetEnumerable()
        {
            for (int i = 0; i < _entriesContainer.Count; ++i)
            {
                foreach (var entry in _entriesContainer[i])
                {
                    yield return entry;
                }
            }
        }

        public int HashFun(T value)
        {
            var hash = value.GetHashCode();
            if (hash < 0)
            {
                hash = hash - Int32.MinValue;
            }
            return hash % capacity;
        }

        public int Size()
        {
            return _size;
        }

        public void Put(T value)
        {
            int hashIndex = HashFun(value);

            if (_entriesContainer[hashIndex].Contains(value))
            {
                return;
            }
            
            _entriesContainer[hashIndex].AddFirst(value);
            ++_size;
        }

        public bool Get(T value)
        {
            int hashIndex = HashFun(value);
            return _entriesContainer[hashIndex].Contains(value);
        }

        public bool Remove(T value)
        {
            int hashIndex = HashFun(value);
            var entry = _entriesContainer[hashIndex].Find(value);
            if (entry != null)
            {
                _entriesContainer[hashIndex].Remove(entry);
                --_size;
                return true;
            }

            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();
            for (int i = 0; i < capacity; ++i)
            {
                foreach (var entry in _entriesContainer[i])
                {
                    if (Get(entry) && set2.Get(entry))
                    {
                        result.Put(entry);
                    }
                }
            }
            
            return result;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();
            foreach (var entry in GetEnumerable())
            {
                result.Put(entry);
            }

            foreach (var entry in set2.GetEnumerable())
            {
                result.Put(entry);
            }
            
            return result;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();
            foreach (var entry in GetEnumerable())
            {
                if (!set2.Get(entry))
                {
                    result.Put(entry);
                }
            }
            
            return result;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            foreach (var entry in set2.GetEnumerable())
            {
                if (!Get(entry))
                {
                    return false;
                }
            }

            return true;
        }
    }
}