using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Stack
{
    [TestClass]
    public class PostfixExpressionHandlerTests
    {
        [TestMethod]
        public void Calculate_SimpleExpression_CorrectResult()
        {
            Assert.AreEqual(59, PostfixExpressionHandler.Calculate("8 2 + 5 * 9 + ="));
        }
    }
}