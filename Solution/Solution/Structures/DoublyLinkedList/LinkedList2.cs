using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value) 
        { 
            value = _value; 
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }
        
        public LinkedList2(params int[] values) : this()
        {
            foreach (var value in values)
            {
                AddInTail(new Node(value));
            }
        }
        
        public static bool operator ==(LinkedList2 first, LinkedList2 second)
        {
            int firstCount = first.Count();
            int secondCount = second.Count();
            
            if (firstCount != secondCount)
            {
                return false;
            }

            if (firstCount == 0)
            {
                return true;
            }

            if (first.head.value != second.head.value || first.tail.value != second.tail.value)
            {
                return false;
            }

            Node firstNode = first.head;
            Node secondNode = second.head;

            while (firstNode != null)
            {
                if (firstNode.value != secondNode.value)
                {
                    return false;
                }
                
                firstNode = firstNode.next;
                secondNode = secondNode.next;
            }

            firstNode = first.tail;
            secondNode = second.tail;

            while (firstNode != null)
            {
                if (firstNode.value != secondNode.value)
                {
                    return false;
                }
                
                firstNode = firstNode.prev;
                secondNode = secondNode.prev;
            }

            return true;
        }

        public static bool operator !=(LinkedList2 first, LinkedList2 second)
        {
            return !(first == second);
        }

        public void AddInTail(Node _item)
        {
            if (head == null) 
            {
                head = _item;
                head.next = null;
                head.prev = null;
            } 
            else 
            {
                tail.next = _item;
                _item.prev = tail;
            }
            
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
                    RemoveNode(prev, node);
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
                    RemoveNode(prev, node);
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
            if (head == null)
            {
                head = _nodeToInsert;
                tail = _nodeToInsert;
                return;

            }

            if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head.prev = _nodeToInsert;
                head = _nodeToInsert;

                return;
            }

            Node next = _nodeAfter.next;
            _nodeAfter.next = _nodeToInsert;
            _nodeToInsert.next = next;
            _nodeToInsert.prev = _nodeAfter;

            if (_nodeToInsert.next != null)
            {
                _nodeToInsert.next.prev = _nodeToInsert;
            }

            if (_nodeAfter == tail)
            {
                tail = _nodeToInsert;
            }
        }

        private void RemoveNode(Node prev, Node nodeToDelete)
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
    }
}