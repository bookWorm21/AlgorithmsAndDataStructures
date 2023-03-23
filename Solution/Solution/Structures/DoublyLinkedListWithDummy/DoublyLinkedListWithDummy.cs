using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures.DummyList
{
    public abstract class Node
    {
        public Node Next;
        public Node Prev;

        public abstract int Value { get; set; }
    }

    public class RealNode : Node
    {
        public sealed override int Value { get; set; }

        public RealNode(int value)
        {
            Value = value;
        }
    }

    public class DummyNode : Node
    {
        public override int Value
        {
            get => throw new Exception("Dummy node haven't value");
            set => throw new Exception("Dummy node haven't value");
        }
    }
    
    public class DoublyLinkedListWithDummy
    {
        public Node head => dummyNode.Next;
        public Node tail => dummyNode.Prev;

        private readonly Node dummyNode;

        public DoublyLinkedListWithDummy()
        {
            dummyNode = new DummyNode();
            dummyNode.Next = dummyNode;
            dummyNode.Prev = dummyNode;
        }
        
        public DoublyLinkedListWithDummy(params int[] values) : this()
        {
            foreach (var value in values)
            {
                AddInTail(new RealNode(value));
            }
        }
        
        public static bool operator ==(DoublyLinkedListWithDummy first, DoublyLinkedListWithDummy second)
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

            if (first.head.Value != second.head.Value || first.tail.Value != second.tail.Value)
            {
                return false;
            }
            
            return first.ForwardEnumerable().SequenceEqual(second.ForwardEnumerable())
                && first.BackEnumerable().SequenceEqual(second.BackEnumerable());
        }

        public static bool operator !=(DoublyLinkedListWithDummy first, DoublyLinkedListWithDummy second)
        {
            return !(first == second);
        }

        public IEnumerable<int> ForwardEnumerable()
        {
            Node current = dummyNode.Next;
            while (current is RealNode)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public IEnumerable<int> BackEnumerable()
        {
            Node current = dummyNode.Prev;
            while (current is RealNode)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }

        public void AddInTail(Node _item)
        {
            _item.Next = dummyNode;
            _item.Prev = dummyNode.Prev;
            dummyNode.Prev.Next = _item;
            dummyNode.Prev = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node is RealNode)
            {
                if (node.Value == _value) 
                    return node;
                
                node = node.Next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node is RealNode)
            {
                if (node.Value == _value)
                {
                    nodes.Add(node);
                }
                
                node = node.Next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node node = head;
            while (node is RealNode)
            {
                if (node.Value == _value)
                {
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                    return true;
                }
                
                node = node.Next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            Node node = head;
            while (node is RealNode)
            {
                if (node.Value == _value)
                {
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                }

                node = node.Next;
            }
        }

        public void Clear()
        {
            dummyNode.Next = dummyNode;
            dummyNode.Prev = dummyNode;
        }

        public int Count()
        {
            int count = 0;
            Node node = head;
            while (node is RealNode)
            {
                ++count;
                node = node.Next;
            }
            
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            _nodeAfter ??= dummyNode;

            var temp = _nodeAfter.Next;
            _nodeAfter.Next = _nodeToInsert;
            _nodeToInsert.Next = temp;
            _nodeToInsert.Prev = _nodeAfter;
            temp.Prev = _nodeToInsert;
        }
    }
}