using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;

        private int[] _bits;
        private readonly int sectionSize;
        private static int SingleMask; 

        public BloomFilter(int f_len)
        {
            filter_len = f_len;

            sectionSize = sizeof(int) * 8;
            int sectionCount = (int) Math.Ceiling((float) f_len / sectionSize);
            _bits = new int[sectionCount];
            
            for (int i = 0; i < sectionCount; ++i)
            {
                _bits[i] = 0;
            }

            for (int i = 0; i < sectionSize; ++i)
            {
                SingleMask |= 1 << i;
            }
        }
        
        public int Hash1(string str1)
        {
            int value = 17;
            int code = 1;
            for (int i = 0; i < str1.Length; i++)
            {
                code *= value;
                code += str1[i];
                code %= filter_len;
            }

            return code;
        }

        public int Hash2(string str1)
        {
            int value = 223;
            int code = 1;
            for (int i = 0; i < str1.Length; i++)
            {
                code *= value;
                code += str1[i];
                code %= filter_len;
            }

            return code;
        }

        public void Add(string str1)
        {
            int hash1 = Hash1(str1);
            WriteBit(hash1, 1);
            int hash2 = Hash2(str1);
            WriteBit(hash2, 1);
        }

        public bool IsValue(string str1)
        {
            int hash1 = Hash1(str1);
            int hash2 = Hash2(str1);
            return ReadBit(hash1) > 0 && ReadBit(hash2) > 0;
        }

        public void WriteBit(int index, int value)
        {
            int sectionIndex = index / sectionSize;
            int section = _bits[sectionIndex];
            int bitNumber = index % sectionSize;

            int mask = SingleMask ^ (1 << bitNumber);
            section = (section & mask) | (value << bitNumber);
            _bits[sectionIndex] = section;
        }
        
        public int ReadBit(int index)
        {
            int section = _bits[index / sectionSize];
            int bitNumber = index % sectionSize;
            return (section & (1 << bitNumber)) > 0 ? 1 : 0;
        }
    }
}