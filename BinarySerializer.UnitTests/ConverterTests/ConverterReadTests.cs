using System;
using System.IO;
using BinarySerializer.Converters.Base;
using BinarySerializer.Converters.Registry;
using BinarySerializer.UnitTests.ConverterTests.CaseSources;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests
{
    [TestFixture]
    public class ConverterReadTests
    {
        [Test]
        [TestCaseSource(typeof(BooleanObjectConverterTestCaseSource), nameof(BooleanObjectConverterTestCaseSource.GetSubCases))]
        public void TestSubConvertersRead(object expected, object source, Type type)
        {
            Assert.AreEqual(expected, ((ISubConverter) Activator.CreateInstance(type)).Read(source));
        }

        [Test]
        [TestCaseSource(typeof(BooleanObjectConverterTestCaseSource))]
        public void TestSubConvertersResolvedRead(object expected, byte[] source, Type type)
        {
            var registry = new ConverterRegistry();
            registry.AddConverter((dynamic)Activator.CreateInstance(type));

            var converter = registry.GetConverter(expected.GetType());

            TestConverterRead(expected, source, converter);
        }

        [Test]
        [TestCaseSource(typeof(BooleanConverterTestCaseSource))]
        [TestCaseSource(typeof(StringConverterTestCaseSource))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetLongCases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetInt32Cases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetByteCases))]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetSByteCases))]
        public void TestConvertersRead(object expected, byte[] source, Type type)
        {
            var converter = ((IConverter) Activator.CreateInstance(type));
            TestConverterRead(expected, source, converter);
        }

        private static void TestConverterRead(object expected, byte[] source, IConverter converter)
        {
            var buffer = new byte[source.Length + 10];
            source.CopyTo(buffer, 0);
            using (var stream = new MemoryStream(buffer))
            {
                Assert.AreEqual(expected, converter.Read(stream).Value);
                Assert.AreEqual(source.Length, stream.Position);
            }
        }

    }
}