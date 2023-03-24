using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Stack
{
    [TestClass]
    public class BracketSequenceCheckerTests
    {
        [TestMethod]
        public void Check_BracketSequences_CorrectAnswer()
        {
            Assert.AreEqual(true, BracketSequenceChecker.Check("(()((())()))"));
            Assert.AreEqual(true, BracketSequenceChecker.Check("(((())))(((())()))"));
            Assert.AreEqual(false, BracketSequenceChecker.Check("(()()(()"));
            Assert.AreEqual(false, BracketSequenceChecker.Check("())("));
            Assert.AreEqual(false, BracketSequenceChecker.Check("((())"));
            Assert.AreEqual(false, BracketSequenceChecker.Check("))(("));
        }
    }
}