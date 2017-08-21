using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blocker.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Blocker blocker = new Blocker(new Configuration());
            blocker.CreateBlock<StringBlock>();
            
        }
    }
}
