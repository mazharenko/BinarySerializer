using System;
using System.IO;
using BinarySerializer.Converters;
using BinarySerializer.Converters.Base;
using BinarySerializer.Converters.Registry;
using BinarySerializer.UnitTests.ConverterTests.CaseSources;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests
{
    [TestFixture]
    public class ConverterWriteTests
    {
        [Test]
        [TestCaseSource(typeof(BooleanObjectConverterTestCaseSource), nameof(BooleanObjectConverterTestCaseSource.GetSubCases))]
        public void TestSubConvertersRead(object source, object expected, Type type)
        {
            Assert.AreEqual(expected, ((ISubConverter) Activator.CreateInstance(type)).Write(source));
        }

        [Test]
        [TestCaseSource(typeof(BooleanObjectConverterTestCaseSource))]
        public void TestSubConvertersResolvedRead(object source, byte[] expected, Type type)
        {
            var registry = new ConverterRegistry();
            registry.AddConverter((dynamic)Activator.CreateInstance(type));

            var converter = registry.GetConverter(source.GetType());

            TestConverterWrite(source, expected, converter);
        }

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
            TestConverterWrite(source, expected, (IConverter) Activator.CreateInstance(type));
        }

        private static void TestConverterWrite(object source, byte[] expected, IConverter converter)
        {
            using (var stream = new MemoryStream())
            {
                converter.Write(source, stream);
                CollectionAssert.AreEqual(expected, stream.ToArray());
            }
        }

    }
}