using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.HashTable
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void HashFun_SameString_SameHash()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var s1 = "hello, my!";
            var s2 = "hello, my!";
            Assert.IsTrue(hashTable.HashFun(s1) == hashTable.HashFun(s2));
        }

        [TestMethod]
        public void HashFun_StringsWithBitDifferent_DifferentHash()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var s1 = "hello, my name is Andrew!";
            var s2 = "hello, my name's Andrew!";
            Assert.IsFalse(hashTable.HashFun(s1) == hashTable.HashFun(s2));
        }

        [TestMethod]
        public void HashFun_StringWithGreatlyDifferent_DifferentHash()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var s1 = "hello, hello, hi-pi";
            var s2 = "it is beautiful life, oooo-oooo, hello";
            Assert.IsFalse(hashTable.HashFun(s1) == hashTable.HashFun(s2));
        }

        [TestMethod]
        public void SeekSlot_String_HashIndexEqualSeekSlotIndex()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var s1 = "hello, my!";
            var hashIndex = hashTable.HashFun(s1);
            var seekSlot = hashTable.SeekSlot(s1);
            Assert.IsTrue(hashIndex == seekSlot);
        }
        
        [TestMethod]
        public void SeekSlot_StringWithSameHash_CorrectlySlots()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var s1 = "hello, my!";
            var hashIndex = hashTable.HashFun(s1);
            hashTable.slots[hashIndex] = "no-no-no, it is my slot";
            var actual = hashTable.SeekSlot(s1);
            Assert.AreEqual((hashIndex + hashTable.step) % hashTable.size, actual);
        }

        [TestMethod]
        public void SeekSlot_AllSlotsBusy_NotSuccessResult()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            for (int i = 0; i < hashTable.slots.Length; ++i)
            {
                hashTable.slots[i] = "against slot busy";
            }

            var actual = hashTable.SeekSlot("give me slot");
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void Put_Strings_HashIndexEqualPuttedIndex()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var hashIndex = hashTable.HashFun("give me slot");
            var puttedIndex = hashTable.Put("give me slot");

            Assert.IsTrue(hashIndex == puttedIndex);
        }

        [TestMethod]
        public void Put_OnBusySlot_CorrectFreeSlot()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var hashIndex = hashTable.HashFun("give me slot");
            hashTable.slots[hashIndex] = "this is slot not empty";
            var expected = (hashIndex + hashTable.step) % hashTable.size;
            var actual = hashTable.Put("give me slot");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Put_AllSlotsBusy_NotSuccessResult()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            for (int i = 0; i < hashTable.slots.Length; ++i)
            {
                hashTable.slots[i] = "against slot busy";
            }

            var actual = hashTable.Put("give me slot");
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void Find_EmptyTable_NotSuccessResult()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var expected = -1;
            var actual = hashTable.Find("give me slot");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_SomeString_HashIndexEqualWithFindingIndex()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var adding = "give me slot";
            var hashIndex = hashTable.HashFun(adding);
            var putted = hashTable.Put(adding);
            var actual = hashTable.Find(adding);

            Assert.IsTrue(hashIndex == putted);
            Assert.IsTrue(putted == actual);
        }

        [TestMethod]
        public void Find_SomeStringWhichCollision_CorrectIndex()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var adding = "give me slot";
            var hashIndex = hashTable.HashFun(adding);
            hashTable.slots[hashIndex] = "busy slot";
            hashTable.Put(adding);
            var actual = hashTable.Find(adding);
            var expected = (hashIndex + hashTable.step) % hashTable.size;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_SomeStringWhichTableNotContains_NotSuccessResult()
        {
            var hashTable = new AlgorithmsDataStructures.HashTable(19, 3);
            var adding = "give me slot";
            var hashIndex = hashTable.HashFun(adding);
            hashTable.slots[hashIndex] = "busy slot";
            var actual = hashTable.Find("give me slot");
            var expected = -1;

            Assert.AreEqual(expected, actual);
        }
    }
}