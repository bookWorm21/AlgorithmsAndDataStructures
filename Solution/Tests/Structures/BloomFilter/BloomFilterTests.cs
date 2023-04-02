using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.BloomFilter
{
    [TestClass]
    public class BloomFilterTests
    {
        [TestMethod]
        public void ReadWriteTest()
        {
            AlgorithmsDataStructures.BloomFilter filter = new AlgorithmsDataStructures.BloomFilter(32);
            var actual = filter.ReadBit(0);
            var expected = 0;

            Assert.AreEqual(expected, actual);

            filter.WriteBit(0, 1);
            actual = filter.ReadBit(0);
            expected = 1;
            
            Assert.AreEqual(expected, actual);

            filter.WriteBit(0, 0);
            actual = filter.ReadBit(0);
            expected = 0;

            Assert.AreEqual(expected, actual);

            filter.WriteBit(1, 1);
            filter.WriteBit(1, 1);

            actual = filter.ReadBit(1);
            expected = 1;

            Assert.AreEqual(expected, actual);

            filter.WriteBit(3, 1);
            filter.WriteBit(4, 1);
            filter.WriteBit(30, 1);

            Assert.AreEqual(1, filter.ReadBit(1));
            Assert.AreEqual(1, filter.ReadBit(4));
            Assert.AreEqual(1, filter.ReadBit(30));
            Assert.AreEqual(0, filter.ReadBit(31));
        }

        [TestMethod]
        public void Add_SomeString_PresenceOnFilter()
        {
            var filter = new AlgorithmsDataStructures.BloomFilter(32);
            var strings = new List<string>()
            {
                "0123456789",
                "1234567890",
                "2345678901",
                "3456789012",
                "4567890123",
                "5678901234",
                "6789012345",
                "7890123456",
                "8901234567",
                "9012345678",
            };

            foreach (var str in strings)
            {
                filter.Add(str);
            }

            foreach (var str in strings)
            {
                Assert.AreEqual(true, filter.IsValue(str));
            }
        }
    }
}