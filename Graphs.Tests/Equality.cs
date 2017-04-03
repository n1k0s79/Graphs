using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphs.Tests
{
    [TestClass]
    public class Equality
    {
        [TestMethod]
        public void CheckNodeEquality()
        {
            Node nullNodeA = null;
            Node nullNodeB = null;
            
            Assert.IsTrue(nullNodeA == null);
            Assert.IsFalse(nullNodeA != null);

            Assert.IsTrue(nullNodeA == nullNodeB);
            Assert.IsFalse(nullNodeA != nullNodeB);

            var a = new Node("A");
            var b = new Node("B");
            var a2 = new Node("A");

            Assert.IsTrue(a == a2);
            Assert.IsFalse(a == b);
            Assert.IsFalse(a == nullNodeA);
            Assert.IsFalse(nullNodeA == a);
        }
    }
}