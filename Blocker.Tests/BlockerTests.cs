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
            var blocker = new Blocker<StringBlock>(new Configuration
            {
                BlockCount = 10,
                KeySize = 5,
                DataSize = 10,
                IndexType = IndexType.Internal
            });

            for (int i = 0; i < 10; i++)
            {
                var block = blocker.CreateBlockInstance();
                block.Key = i.ToString();
                block.Data = $"data{i}";
                blocker.Add(block);
            }

            var findBlock = blocker.CreateBlockInstance();
            findBlock.Key = "5";
            blocker.Find(findBlock);

            Assert.AreEqual(findBlock.Data, "data5");
        }
    }
}
