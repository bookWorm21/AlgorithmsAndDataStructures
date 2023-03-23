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
            MakeArray(MinCapacity);
        }

        public void MakeArray(int new_capacity)
        {
            if (capacity == new_capacity)
            {
                return;
            }
            
            var temp = new T[new_capacity];
            Array.ConstrainedCopy(array, 0, temp, 0, new_capacity);
            array = temp;
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
            ++count;
            TryExpansion();
            array[count - 1] = itm;
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

            ++count;
            TryExpansion();
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
                --count;
                TryConstriction();
                return;
            }
            
            Array.ConstrainedCopy(array, index + 1, array, index, count - 1 - index);
            --count;
            TryConstriction();
        }

        private bool TryExpansion()
        {
            if (count > capacity)
            {
                MakeArray(capacity * ExpansionValue);
                return true;
            }

            return false;
        }

        private bool TryConstriction()
        {
            if (count < capacity * OccupancyForConstriction)
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