using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void AddInTail_EmptyList_CorrectHeadAndTail()
        {
            LinkedList list = new LinkedList();
            Node adding = new Node(5);
            list.AddInTail(adding);

            Assert.AreEqual(adding, list.head);
            Assert.AreEqual(adding, list.tail);
        }

        [TestMethod]
        public void AddInTail_ListWithOneElement_CorrectHeadAndTail()
        {
            LinkedList list = new LinkedList();
            Node first = new Node(5);
            Node second = new Node(3);
            list.AddInTail(first);
            list.AddInTail(second);
            Assert.AreEqual(first, list.head);
            Assert.AreEqual(second, list.tail);
        }

        [TestMethod]
        public void AddInTail_ListWithTwoElement_CorrectHeadAndTail()
        {
            LinkedList list = new LinkedList();
            Node first = new Node(3);
            Node second = new Node(5);
            Node third = new Node(0);
            list.AddInTail(first);
            list.AddInTail(second);
            list.AddInTail(third);

            Assert.AreEqual(first, list.head);
            Assert.AreEqual(third, list.tail);
            Assert.AreEqual(first.next, second);
            Assert.AreEqual(second.next, third);
        }
        
        [TestMethod]
        public void Find_EmptyList_Null()
        {
            LinkedList list = new LinkedList();
            Node actual = list.Find(10);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Find_ListWithOtherOneElement_Null()
        {
            LinkedList list = new LinkedList();
            list.AddInTail(new Node(-3));
            Node actual = list.Find(10);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Find_ListWithNeededOneElement_ThisElement()
        {
            LinkedList list = new LinkedList();
            int value = 5;
            Node expected = new Node(value);
            list.AddInTail(expected);
            Node actual = list.Find(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_ListWithElementsWithSameValue_FirstElement()
        {
            LinkedList list = new LinkedList();
            int value = 5;
            Node expected = new Node(value);
            list.AddInTail(new Node(3));
            list.AddInTail(expected);
            list.AddInTail(new Node(4));
            list.AddInTail(new Node(5));
            list.AddInTail(new Node(7));
            Node actual = list.Find(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAll_ListWithoutNeededElements_EmptyResult()
        {
            LinkedList list = new LinkedList();
            int value = 5;
            list.AddInTail(new Node(3));
            list.AddInTail(new Node(4));
            list.AddInTail(new Node(2));
            list.AddInTail(new Node(7));

            int expected = 0;
            var actual = list.FindAll(value).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAll_ListWithSeveralNeededElements_AllElements()
        {
            LinkedList list = new LinkedList();
            int value = 5;
            list.AddInTail(new Node(3));
            Node first = new Node(value);
            list.AddInTail(first);
            list.AddInTail(new Node(4));
            Node second = new Node(value);
            list.AddInTail(second);
            list.AddInTail(new Node(7));

            var result = list.FindAll(value);

            if (result.Count < 2)
            {
                Assert.Fail();
                return;
            }

            Assert.AreEqual(first, result[0]);
            Assert.AreEqual(second, result[1]);
        }

        [TestMethod]
        public void Remove_ListWithoutNeededElement_False()
        {
            LinkedList list = new LinkedList(5, 3, 7, 8, 9);
            bool expected = false;
            bool actual = list.Remove(10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ListWithNeededElement_True()
        {
            LinkedList expected = new LinkedList(5, 3, 7, 8, 9);
            int valueRemove = 3;
            LinkedList actual = new LinkedList(5, 7, 8, 9);
            expected.Remove(valueRemove);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void Remove_ListWithSeveralNeededElement_RemoveFirstElementOnList()
        {
            LinkedList expected = new LinkedList(5, 3, 7, 8, 3, 9);
            int valueRemove = 3;
            LinkedList actual = new LinkedList(5, 7, 8, 3, 9);
            expected.Remove(valueRemove);

            Assert.IsTrue(expected == actual);
        }
        
        [TestMethod]
        public void RemoveAll_ListWithSeverNeededElement_ListWithoutThisElements()
        {
            LinkedList expected = new LinkedList(5, 3, 7, 8, 3, 9, 3, 3);
            int valueRemove = 3;
            LinkedList actual = new LinkedList(5, 7, 8, 9);
            expected.RemoveAll(valueRemove);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void Count_EmptyList_0()
        {
            LinkedList list = new LinkedList();
            var expected = 0;
            var actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Count_ListWithOneElement_1()
        {
            LinkedList list = new LinkedList(1);
            var expected = 1;
            var actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Count_ListWithSeveralElements_CorrectValue()
        {
            LinkedList list = new LinkedList(5, 3, 7, 8, 9);
            var expected = 5;
            var actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Clear_ListWithSeveralElements_EmptyList()
        {
            LinkedList list = new LinkedList(5, 3, 8, 7, 9);
            var expected = 0;
            list.Clear();
            var actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertAfter_InsertAfterNull_HeadIsInsertedNode()
        {
            LinkedList list = new LinkedList(5, 3, 7, 8, 9, 10);
            Node expected = new Node(5);
            list.InsertAfter(null, expected);

            Assert.AreEqual(expected, list.head);
        }

        [TestMethod]
        public void InsertAfter_InsertAfterTail_NewTailIsInsertedNode()
        {
            LinkedList list = new LinkedList(5, 3, 7, 8, 9, 10);
            Node expected = new Node(5);
            list.InsertAfter(list.tail, expected);

            Assert.AreEqual(expected, list.tail);
        }

        [TestMethod]
        public void InsertAfter_InsertInEmptyList_NewTailAndHeadIsInsertedNode()
        {
            LinkedList list = new LinkedList();
            Node expected = new Node(5);
            list.InsertAfter(null, expected);

            Assert.AreEqual(expected, list.head);
            Assert.AreEqual(expected, list.tail);
        }

        [TestMethod]
        public void InsertAfter_InsertOnMiddleList_CorrectList()
        {
            LinkedList actual = new LinkedList(5, 3, 7, 8, 9, 10);
            Node adding = new Node(5);
            actual.InsertAfter(actual.Find(7), adding);
            
            LinkedList expected = new LinkedList(5, 3, 7, 5, 8, 9, 10);

            Assert.IsTrue(expected == actual);
        }
    }
}