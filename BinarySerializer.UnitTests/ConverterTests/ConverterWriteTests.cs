using System;
using System.IO;
using BinarySerializer.Converters;
using BinarySerializer.UnitTests.ConverterTests.CaseSources;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests
{
    [TestFixture]
    public class ConverterWriteTests
    {
        [Test]
        [TestCaseSource(typeof(BooleanConverterTestCaseSource))]
        [TestCaseSource(typeof(StringConverterTestCaseSource))]
        [TestCaseSource(typeof(StringConverterTestCaseSource), nameof(StringConverterTestCaseSource.GetWriteCases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetLongCases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetInt32Cases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetByteCases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetSByteCases))]
        public void TestConvertersWrite(object source, byte[] expected, Type type)
        {
            using (var stream = new MemoryStream())
            {
                ((IConverter) Activator.CreateInstance(type)).Write(source, stream);
                CollectionAssert.AreEqual(expected, stream.ToArray());
            }
        }
    }
}