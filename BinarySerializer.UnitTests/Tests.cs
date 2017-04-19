using System;
using BinarySerializer.UnitTests.Contracts;
using NUnit.Framework;

namespace BinarySerializer.UnitTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Test2()
        {
            Assert.IsTrue(typeof(Enum).IsAssignableFrom(typeof(A)));

        }

        enum A
        {
            d,
            b
        }
    }
}