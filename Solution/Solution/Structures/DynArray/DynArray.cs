using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class DynArray<T>
    {
        public T [] array;
        public int count;
        public int capacity;

        private const int MinCapacity = 16;
        private const int ExpansionValue = 2;
        private const float ConstrictionValue = 1.5f;
        private const float OccupancyForConstriction = 0.5f;

        public DynArray()
        {
            count = 0;
            array = Array.Empty<T>();
            MakeArray(MinCapacity);
        }

        public DynArray(params T[] values)
        {
            array = Array.Empty<T>();
            MakeArray(Math.Max(values.Length, MinCapacity));
            count = values.Length;
            Array.ConstrainedCopy(values, 0, array, 0, values.Length);
        }

        public static bool operator ==(DynArray<T> first, DynArray<T> second)
        {
            if (Equals(first, null) && Equals(second, null))
            {
                return true;
            }

            if (Equals(first, null) || Equals(second, null))
            {
                return false;
            }

            if (first.count != second.count)
            {
                return false;
            }

            for (int i = 0; i < first.count; ++i)
            {
                if (!Equals(first.GetItem(i), second.GetItem(i)))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(DynArray<T> first, DynArray<T> second)
        {
            return !(first == second);
        }

        private bool Equals(DynArray<T> other)
        {
            return Equals(array, other.array) && count == other.count && capacity == other.capacity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;
            if (ReferenceEquals(this, obj)) 
                return true;
            if (obj.GetType() != GetType()) 
                return false;
            
            return Equals((DynArray<T>) obj);
        }

        public void MakeArray(int new_capacity)
        {
            if (capacity == new_capacity)
            {
                return;
            }
            
            var temp = new T[new_capacity];
            Array.ConstrainedCopy(array, 0, temp, 0, Math.Min(new_capacity, count));
            array = temp;
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            return array[index];
        }

        public void Append(T itm)
        {
            TryExpansion();
            array[count] = itm;
            ++count;
        }

        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }
            
            if (index == count)
            {
                Append(itm);
                return;
            }
            
            TryExpansion();
            ++count;
            Array.ConstrainedCopy(array, index, array, index + 1, count - 1 - index);
            array[index] = itm;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == count - 1)
            {
                TryConstriction();
                --count;
                return;
            }
            
            Array.ConstrainedCopy(array, index + 1, array, index, count - 1 - index);
            TryConstriction();
            --count;
        }

        private bool TryExpansion()
        {
            if (count == capacity)
            {
                MakeArray(capacity * ExpansionValue);
                return true;
            }

            return false;
        }

        private bool TryConstriction()
        {
            if (count <= capacity * OccupancyForConstriction)
            {
                int newCapacity = (int)(capacity / ConstrictionValue);
                newCapacity = Math.Max(newCapacity, MinCapacity);
                MakeArray(newCapacity);
                return true;
            }

            return false;
        }
    }
}