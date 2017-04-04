using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trees.Tests
{
    [TestClass]
    public class Generation
    {
        [TestMethod]
        public void RandomGeneration()
        {
            var generator = new Trees.Generator();
            var InputTree = generator.GenerateBinaryTree(20);
            var array = InputTree.ToIntArray();
            var outputTree = BTree.FromArray(array);
            Assert.IsTrue(InputTree.SameAs(outputTree));
        }

        [TestMethod]
        public void RandomGenerationNumberOfNodes()
        {
            var generator = new Generator();
            for (int i = 10; i < 1000; i++)
            {
                var InputTree = generator.GenerateBinaryTree(i);
                Assert.AreEqual(i, InputTree.Nodes.Count);
            }
        }

        [TestMethod]
        public void ArrayGeneration()
        {
            var input = new int[] {1, 3, 1, -1, 3};
            var testdomeTree = BTree.FromArray(input);
            var output = testdomeTree.ToIntArray();
            Assert.IsTrue(AreEqual(input, output));
        }

        private bool AreEqual(int[] a, int [] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }

            return true;
        }
    }
}