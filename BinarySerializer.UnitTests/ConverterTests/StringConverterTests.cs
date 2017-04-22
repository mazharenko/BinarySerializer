using System;
using System.IO;
using BinarySerializer.Converters;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests
{
    [TestFixture]
    public class StringConverterTests
    {
        [Test]
        public void TestWriteNull()
        {
            Assert.Throws<ArgumentNullException>(() => new StringConverter().Write(null, Stream.Null));
        }
    }
}