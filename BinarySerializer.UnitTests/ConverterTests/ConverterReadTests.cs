using System;
using System.IO;
using BinarySerializer.Converters;
using BinarySerializer.UnitTests.ConverterTests.CaseSources;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests
{
    [TestFixture]
    public class ConverterReadTests
    {
        [Test]
        [TestCaseSource(typeof(BooleanConverterTestCaseSource))]
        [TestCaseSource(typeof(StringConverterTestCaseSource))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetLongCases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetInt32Cases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetByteCases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetSByteCases))]
        public void TestConvertersRead(object expected, byte[] source, Type type)
        {
            var buffer = new byte[source.Length + 10];
            source.CopyTo(buffer, 0);
            var stream = new MemoryStream(buffer);
            using (stream)
            {
                Assert.AreEqual(expected, ((IConverter) Activator.CreateInstance(type)).Read(stream).Value);
                Assert.AreEqual(source.Length, stream.Position);
            }
        }
    }
}