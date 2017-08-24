using System;
using Blocker.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blocker.Tests
{
    [TestClass]
    public class BlockerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var conf = new Configuration
            {
                BlockCount = 10,
                KeySize = 5,
                DataSize = 10,
                IndexType = IndexType.None
            };
            var blocker = new Blocker<StringBlock>(conf);

            for (int i = 0; i < blocker.Length; i++)
            {
                blocker[i] = new StringBlock(conf)
                {
                    Key = $"{i}",
                    Data = $"data{i}"
                };
            }

            var findBlock = blocker.Find(new StringBlock(conf, "5"));
            Assert.AreEqual(findBlock.Data, "data5");
        }
    }
}
