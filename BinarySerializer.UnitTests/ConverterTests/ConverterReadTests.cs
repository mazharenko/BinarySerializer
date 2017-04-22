using System;
using System.IO;
using BinarySerializer.Converters;
using BinarySerializer.Converters.Integer;
using BinarySerializer.UnitTests.ConverterTests.Cases;
using BinarySerializer.UnitTests.ConverterTests.CaseSources;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests
{
    [TestFixture]
    public class ConverterReadTests
    {
        [Test]
        [TestCaseSource(typeof(BooleanConverterTestCaseSource))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetLongCases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetInt32Cases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetByteCases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetSByteCases))]
        public void TestConvertersWrite(object expected, byte[] source, Type type)
        {
            var stream = new MemoryStream(source);
            Assert.AreEqual(expected, ((IConverter)Activator.CreateInstance(type)).Read(stream).Value);
        }
    }
}