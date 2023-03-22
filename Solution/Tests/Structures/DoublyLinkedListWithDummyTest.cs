using AlgorithmsDataStructures;
using AlgorithmsDataStructures.DummyList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Node = AlgorithmsDataStructures.DummyList.Node;

namespace Tests
{
    [TestClass]
    public class DoublyLinkedListWithDummyTest
    {
        [TestMethod]
        public void AddInTail_EmptyList_CorrectHeadAndTail()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            Node adding = new RealNode(5);
            list.AddInTail(adding);

            Assert.AreEqual(adding, list.head);
            Assert.AreEqual(adding, list.tail);
        }

        [TestMethod]
        public void AddInTail_ListWithOneElement_CorrectHeadAndTail()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            Node first = new RealNode(5);
            Node second = new RealNode(3);
            list.AddInTail(first);
            list.AddInTail(second);
            Assert.AreEqual(first, list.head);
            Assert.AreEqual(second, list.tail);
            Assert.AreEqual(second.Prev, first);
        }

        [TestMethod]
        public void AddInTail_ListWithTwoElement_CorrectHeadAndTail()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            Node first = new RealNode(3);
            Node second = new RealNode(5);
            Node third = new RealNode(0);
            list.AddInTail(first);
            list.AddInTail(second);
            list.AddInTail(third);

            Assert.AreEqual(first, list.head);
            Assert.AreEqual(third, list.tail);
            Assert.AreEqual(first.Next, second);
            Assert.AreEqual(second.Next, third);
            Assert.AreEqual(second.Prev, first);
            Assert.AreEqual(third.Prev, second);
        }
        
        [TestMethod]
        public void Find_EmptyList_Null()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            Node actual = list.Find(10);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Find_ListWithOtherOneElement_Null()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            list.AddInTail(new RealNode(-3));
            Node actual = list.Find(10);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Find_ListWithNeededOneElement_ThisElement()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            int value = 5;
            Node expected = new RealNode(value);
            list.AddInTail(expected);
            Node actual = list.Find(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_ListWithElementsWithSameValue_FirstElement()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            int value = 5;
            Node expected = new RealNode(value);
            list.AddInTail(new RealNode(3));
            list.AddInTail(expected);
            list.AddInTail(new RealNode(4));
            list.AddInTail(new RealNode(5));
            list.AddInTail(new RealNode(7));
            Node actual = list.Find(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAll_ListWithoutNeededElements_EmptyResult()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            int value = 5;
            list.AddInTail(new RealNode(3));
            list.AddInTail(new RealNode(4));
            list.AddInTail(new RealNode(2));
            list.AddInTail(new RealNode(7));

            int expected = 0;
            var actual = list.FindAll(value).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAll_ListWithSeveralNeededElements_AllElements()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            int value = 5;
            list.AddInTail(new RealNode(3));
            Node first = new RealNode(value);
            list.AddInTail(first);
            list.AddInTail(new RealNode(4));
            Node second = new RealNode(value);
            list.AddInTail(second);
            list.AddInTail(new RealNode(7));

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
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy(5, 3, 7, 8, 9);
            bool expected = false;
            bool actual = list.Remove(10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ListWithNeededElement_True()
        {
            DoublyLinkedListWithDummy expected = new DoublyLinkedListWithDummy(5, 3, 7, 8, 9);
            int valueRemove = 3;
            DoublyLinkedListWithDummy actual = new DoublyLinkedListWithDummy(5, 7, 8, 9);
            expected.Remove(valueRemove);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void Remove_ListWithSeveralNeededElement_RemoveFirstElementOnList()
        {
            DoublyLinkedListWithDummy expected = new DoublyLinkedListWithDummy(5, 3, 7, 8, 3, 9);
            int valueRemove = 3;
            DoublyLinkedListWithDummy actual = new DoublyLinkedListWithDummy(5, 7, 8, 3, 9);
            expected.Remove(valueRemove);

            Assert.IsTrue(expected == actual);
        }
        
        [TestMethod]
        public void RemoveAll_ListWithSeverNeededElement_ListWithoutThisElements()
        {
            DoublyLinkedListWithDummy expected = new DoublyLinkedListWithDummy(5, 3, 7, 8, 3, 9, 3, 3);
            int valueRemove = 3;
            DoublyLinkedListWithDummy actual = new DoublyLinkedListWithDummy(5, 7, 8, 9);
            expected.RemoveAll(valueRemove);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void Count_EmptyList_0()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            var expected = 0;
            var actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Count_ListWithOneElement_1()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy(1);
            var expected = 1;
            var actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Count_ListWithSeveralElements_CorrectValue()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy(5, 3, 7, 8, 9);
            var expected = 5;
            var actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Clear_ListWithSeveralElements_EmptyList()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy(5, 3, 8, 7, 9);
            var expected = 0;
            list.Clear();
            var actual = list.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertAfter_InsertAfterNull_HeadIsInsertedNode()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy(5, 3, 7, 8, 9, 10);
            Node expected = new RealNode(5);
            list.InsertAfter(null, expected);

            Assert.AreEqual(expected, list.head);
        }

        [TestMethod]
        public void InsertAfter_InsertAfterTail_NewTailIsInsertedNode()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy(5, 3, 7, 8, 9, 10);
            Node expected = new RealNode(5);
            Node expectedPrev = list.tail;
            list.InsertAfter(list.tail, expected);

            Assert.AreEqual(expectedPrev, list.tail.Prev);
            Assert.AreEqual(expected, list.tail);
        }

        [TestMethod]
        public void InsertAfter_InsertInEmptyList_NewTailAndHeadIsInsertedNode()
        {
            DoublyLinkedListWithDummy list = new DoublyLinkedListWithDummy();
            Node expected = new RealNode(5);
            list.InsertAfter(null, expected);

            Assert.AreEqual(expected, list.head);
            Assert.AreEqual(expected, list.tail);
        }

        [TestMethod]
        public void InsertAfter_InsertOnMiddleList_CorrectList()
        {
            DoublyLinkedListWithDummy actual = new DoublyLinkedListWithDummy(5, 3, 7, 8, 9, 10);
            Node adding = new RealNode(5);
            actual.InsertAfter(actual.Find(7), adding);
            
            DoublyLinkedListWithDummy expected = new DoublyLinkedListWithDummy(5, 3, 7, 5, 8, 9, 10);

            Assert.IsTrue(expected == actual);
        }
    }
}