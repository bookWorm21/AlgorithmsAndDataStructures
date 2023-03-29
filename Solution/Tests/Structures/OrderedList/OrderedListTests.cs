using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.OrderedList
{
    [TestClass]
    public class OrderedListTests
    {
        [TestMethod]
        public void Constructor_CreatingListWithValuesCollection_CorrectOrder()
        {
            var values = new List<int> {5, 3, 7};
            var actualList = new OrderedList<int>(true, values.ToArray());
            values.Sort((first, second) =>
            {
                if (first == second)
                    return 0;
                if (first < second)
                    return -1;

                return 1;
            });
            
            var expectedList = new OrderedList<int>(true, values.ToArray());

            Assert.IsTrue(expectedList.GetEnumerable().SequenceEqual(actualList.GetEnumerable()));
        }

        [TestMethod]
        public void Constructor_EmptyList_CorrectHeadAndTail()
        {
            var list = new OrderedList<int>(true);

            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }

        [TestMethod]
        public void Add_AddValueToEmptyList_CorrectHeadAndTailAndList()
        {
            var orderedList = new OrderedList<int>(true);
            var value = 5;
            var expected = new OrderedList<int>(true, value);
            orderedList.Add(value);

            Assert.AreEqual(value, orderedList.head.value);
            Assert.AreEqual(value , orderedList.tail.value);
            Assert.IsTrue(orderedList.GetEnumerable().SequenceEqual(expected.GetEnumerable()));
        }

        [TestMethod]
        public void Add_AddValueToListWithSeveralElements_CorrectOrder()
        {
            var actualList = new OrderedList<int>(true, 5, 3, 7);
            var value = 9;
            var expectedList = new OrderedList<int>(true, 3, 5, 7, 9);
            actualList.Add(value);

            Assert.IsTrue(expectedList.GetEnumerable().SequenceEqual(actualList.GetEnumerable()));
        }

        [TestMethod]
        public void Add_AddValueToNotAscendingListWithSeveralElements_CorrectOrder()
        {
            var actualList = new OrderedList<int>(false, 5, 3, 7);
            var value = 9;
            var expectedList = new OrderedList<int>(false, 9, 7, 5, 3);
            actualList.Add(value);

            Assert.IsTrue(expectedList.GetEnumerable().SequenceEqual(actualList.GetEnumerable()));
        }

        [TestMethod]
        public void Remove_RemoveSomeValue_ListWithCorrectOrder()
        {
            var actualList = new OrderedList<int>(false, 5, 3, 7, 9);
            var value = 9;
            var expectedList = new OrderedList<int>(false, 7, 5, 3);
            actualList.Delete(value);

            Assert.IsTrue(expectedList.GetEnumerable().SequenceEqual(actualList.GetEnumerable()));
        }

        [TestMethod]
        public void Remove_ListWithoutNeededElement_SameOnStartList()
        {
            var actualList = new OrderedList<int>(false, 5, 3, 7);
            var value = 9;
            var expectedList = new OrderedList<int>(false, 7, 5, 3);
            actualList.Delete(value);

            Assert.IsTrue(expectedList.GetEnumerable().SequenceEqual(actualList.GetEnumerable()));
        }

        [TestMethod]
        public void Remove_EmptyList_WithoutErrors()
        {
            var actualList = new OrderedList<int>(false);
            actualList.Delete(9);
        }

        [TestMethod]
        public void Find_ListWithoutNeededElement_Null()
        {
            var actualList = new OrderedList<int>(false, 5, 3, 7);
            var actual = actualList.Find(9);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Find_ListWithNeededElement_CorrectValue()
        {
            var actualList = new OrderedList<int>(true, 3, 7, 8, 9, 11, 25, 101);
            var value = 99;
            actualList.Add(value);
            var actual = actualList.Find(99).value;

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Compare_TwoStrings_CorrectValue()
        {
            var list = new OrderedList<string>(true);
            Assert.AreEqual(0, list.Compare("  hello", "hello  "));
            Assert.AreEqual(-1, list.Compare("123", "124"));
            Assert.AreEqual(-1, list.Compare("123", "124"));
            Assert.AreEqual(1, list.Compare("15789", "  1578"));
        }

        [TestMethod]
        public void GetAll_SomeList_CorrectValues()
        {
            var values = new List<int> {3, 7, 8, 9, 11, 25, 101};
            var list = new OrderedList<int>(false, values.ToArray());

            values.Reverse();
            Assert.IsTrue(list.GetAll().Select(node => node.value).SequenceEqual(values));
        }
    }
}