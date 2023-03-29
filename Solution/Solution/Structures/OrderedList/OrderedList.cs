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

        public OrderedList(bool asc)
        {
            _ascending = asc;
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
            var node = head;
            while (node != null)
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
            var nodeAfter = head;
            bool handleAllList = false;
            while (!handleAllList)
            {
                if (nodeAfter == null)
                {
                    handleAllList = true;
                    break;
                }
                
                var compareResult = Compare(nodeAfter.value, value);

                if (compareResult == 0)
                {
                    break;
                }

                if (_ascending && compareResult > 0)
                {
                    nodeAfter = nodeAfter.prev;
                    break;
                }

                if (!_ascending && compareResult < 0)
                {
                    nodeAfter = nodeAfter.prev;
                    break;
                }

                nodeAfter = nodeAfter.next;
            }

            var insertedNode = new Node<T>(value);
            if (handleAllList)
            {
                nodeAfter = tail;
            }
            InsertAfter(nodeAfter, insertedNode);
        }

        public Node<T> Find(T val)
        {
            var node = head;
            while (node != null)
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
            Node<T> prev = null;
            var node = head;
            while (node != null)
            {
                if (Compare(val, node.value) == 0)
                {
                    RemoveNode(prev, node);
                    return;
                }

                prev = node;
                node = node.next;
            }
        }

        private void InsertAfter(Node<T> after, Node<T> insert)
        {
            if (head == null)
            {
                head = insert;
                tail = insert;
                return;

            }

            if (after == null)
            {
                insert.next = head;
                head.prev = insert;
                head = insert;

                return;
            }

            var next = after.next;
            after.next = insert;
            insert.next = next;
            insert.prev = after;

            if (insert.next != null)
            {
                insert.next.prev = insert;
            }

            if (after == tail)
            {
                tail = insert;
            }
        }
        
        private void RemoveNode(Node<T> prev, Node<T> nodeToDelete)
        {
            if (prev != null)
            {
                prev.next = nodeToDelete.next;
            }
            else
            {
                head = nodeToDelete.next;
            }
                    
            if (nodeToDelete.next != null)
            {
                nodeToDelete.next.prev = prev;
            }

            if (nodeToDelete == tail)
            {
                tail = prev;
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            var current = head;
            while (current != null)
            {
                ++count;
                current = current.next;
            }

            return count;
        }

        public List<Node<T>> GetAll()
        {
            var result = new List<Node<T>>();
            var node = head;
            
            while(node != null)
            {
                result.Add(node);
                node = node.next;
            }
            return result;
        }
    }
}