using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;
        private Node<T> _dummy;

        public OrderedList(bool asc)
        {
            _ascending = asc;
            _dummy = new Node<T>(default);
            _dummy.next = _dummy;
            _dummy.prev = _dummy;
            head = null;
            tail = null;
        }

        public OrderedList(bool asc, params T[] values) : this(asc)
        {
            for (int i = 0; i < values.Length; ++i)
            {
                Add(values[i]);
            }
        }

        public IEnumerable<T> GetEnumerable()
        {
            var node = _dummy.next;
            while (node != _dummy)
            {
                yield return node.value;
                node = node.next;
            }
        }

        public int Compare(T v1, T v2)
        {
            if(typeof(T) == typeof(String))
            {
                var str1 = Convert.ToString(v1);
                var str2 = Convert.ToString(v2);
                
                str1 = str1 != null ? str1 : "";
                str2 = str2 != null ? str2 : "";
                
                return string.CompareOrdinal(str1.Trim(),str2.Trim());
            }

            if(typeof(T) == typeof(int))
            {
                var num1 = Convert.ToInt32(v1);
                var num2 = Convert.ToInt32(v2);

                return num1 == num2 ? 0 : (num1 < num2 ? -1 : 1);
            }

            throw new ArgumentException("Not type handler");
        }

        public void Add(T value)
        {
            var nodeAfter = _dummy.next;
            while (nodeAfter != _dummy)
            {
                var compareResult = Compare(nodeAfter.value, value);

                if (compareResult == 0)
                {
                    nodeAfter = nodeAfter.next;
                    break;
                }

                if (_ascending && compareResult > 0)
                {
                    break;
                }

                if (!_ascending && compareResult < 0)
                {
                    break;
                }

                nodeAfter = nodeAfter.next;
            }

            nodeAfter = nodeAfter.prev;
            var insertedNode = new Node<T>(value);
            var tempNext = nodeAfter.next;
            
            nodeAfter.next = insertedNode;
            insertedNode.next = tempNext;
            insertedNode.prev = nodeAfter;
            tempNext.prev = insertedNode;

            head = _dummy.next;
            tail = _dummy.prev;
        }

        public Node<T> Find(T val)
        {
            var node = _dummy.next;
            while (node != _dummy)
            {
                var compareValue = Compare(node.value, val);

                if (_ascending && compareValue > 0)
                {
                    return null;
                }

                if (!_ascending && compareValue < 0)
                {
                    return null;
                }
                
                if (Compare(node.value, val) == 0)
                {
                    return node;
                }

                node = node.next;
            }

            return null;
        }

        public void Delete(T val)
        {
            var node = _dummy.next;
            while (node != _dummy)
            {
                if (Compare(val, node.value) == 0)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    return;
                }
                
                node = node.next;
            }

            head = _dummy.next;
            tail = _dummy.prev;

            if (head == _dummy)
            {
                head = null;
                tail = null;
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            _dummy.next = _dummy;
            _dummy.prev = _dummy;
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            var current = _dummy.next;
            while (current != _dummy)
            {
                ++count;
                current = current.next;
            }

            return count;
        }

        public List<Node<T>> GetAll()
        {
            var result = new List<Node<T>>();
            var node = _dummy.next;
            
            while(node != _dummy)
            {
                result.Add(node);
                node = node.next;
            }
            return result;
        }
    }
}