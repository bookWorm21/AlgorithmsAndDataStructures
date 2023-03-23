using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DynArrayTests
    {
        [TestMethod]
        public void Insert_SomeValueOnTheMiddle_WithoutExpansionBuffer()
        {
            Random random = new Random(5);
            int expectedCapacity = 32;
            var values = new List<int>(expectedCapacity);
            var actual = new DynArray<int>();
            for (int i = 0; i < expectedCapacity - 1; ++i)
            {
                var randomValue = random.Next(-100000, 100000);
                values.Add(randomValue);
                actual.Append(randomValue);
            }

            actual.Insert(13, 5);
            values.Insert(5, 13);

            var expected = new DynArray<int>(values.ToArray());

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(expectedCapacity, actual.capacity);
            Assert.AreEqual(expectedCapacity, actual.count);
        }

        [TestMethod]
        public void Insert_SomeValueOnTheMiddle_WithExpansionBuffer()
        {
            Random random = new Random(5);
            int expectedCount = 32;
            var values = new List<int>(expectedCount);
            var actual = new DynArray<int>();
            for (int i = 0; i < expectedCount; ++i)
            {
                var randomValue = random.Next(-100000, 100000);
                values.Add(randomValue);
                actual.Append(randomValue);
            }

            actual.Insert(13, 5);
            values.Insert(5, 13);

            var expected = new DynArray<int>(values.ToArray());

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(64, actual.capacity);
            Assert.AreEqual(33, actual.count);
        }

        [TestMethod]
        public void Insert_SomeValueOnOutside_IndexOutException()
        {
            var array = new DynArray<int>(5, 3, 7, 8, 9);
            Assert.ThrowsException<IndexOutOfRangeException>(() => array.Insert(5, 8));
        }

        [TestMethod]
        public void Remove_SomeValueOnMiddle_WithoutConstrictionBuffer()
        {
            Random random = new Random(5);
            int expectedCount = 32;
            var values = new List<int>(expectedCount);
            var actual = new DynArray<int>();
            for (int i = 0; i < expectedCount; ++i)
            {
                var randomValue = random.Next(-100000, 100000);
                values.Add(randomValue);
                actual.Append(randomValue);
            }

            for (int i = 0; i < 16; ++i)
            {
                actual.Remove(5);
                values.RemoveAt(5);
            }
            
            var expected = new DynArray<int>(values.ToArray());

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(32, actual.capacity);
            Assert.AreEqual(16, actual.count);
        }

        [TestMethod]
        public void Remove_SomeValueOnMiddle_WithConstrictionBuffer()
        {
            Random random = new Random(5);
            int expectedCount = 32;
            var values = new List<int>(expectedCount);
            var actual = new DynArray<int>();
            for (int i = 0; i < expectedCount; ++i)
            {
                var randomValue = random.Next(-100000, 100000);
                values.Add(randomValue);
                actual.Append(randomValue);
            }

            for (int i = 0; i < 17; ++i)
            {
                actual.Remove(5);
                values.RemoveAt(5);
            }
            
            var expected = new DynArray<int>(values.ToArray());

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(21, actual.capacity);
            Assert.AreEqual(15, actual.count);
        }

        [TestMethod]
        public void Remove_SomeValueOutside_IndexOutException()
        {
            var array = new DynArray<int>(5, 3, 7, 8, 9);
            Assert.ThrowsException<IndexOutOfRangeException>(() => array.Remove(8));
        }
    }
}