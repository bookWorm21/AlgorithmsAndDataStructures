using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else              tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }
                
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node prev = null;
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (prev != null)
                    {
                        prev.next = node.next;
                    }
                    else
                    {
                        head = node.next;
                    }

                    if (node == tail)
                    {
                        tail = prev;
                    }
                    
                    return true;
                }

                prev = node;
                node = node.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            Node prev = null;
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (prev != null)
                    {
                        prev.next = node.next;
                    }
                    else
                    {
                        head = node.next;
                    }

                    if (node == tail)
                    {
                        tail = prev;
                    }
                }
                else
                {
                    prev = node;
                }
                
                node = node.next;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node node = head;
            while (node != null)
            {
                ++count;
                node = node.next;
            }
            
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head = _nodeToInsert;
                return;
            }

            Node next = _nodeAfter.next;
            _nodeAfter.next = _nodeToInsert;
            _nodeToInsert.next = next;

            if (_nodeAfter == tail)
            {
                tail = _nodeToInsert;
            }
        }
    }
}