using System.IO;
using BinarySerializer.Converters;
using BinarySerializer.Converters.Integer;
using BinarySerializer.UnitTests.ConverterTests.Cases;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests
{
    [TestFixture]
    public class ConverterReadTests
    {
        [Test]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetInt32Cases))]
        public void TestInteger(int expected, byte[] source)
        {
            Test<IntConverter>(expected, source);
        }

        [Test]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetLongCases))]
        public void TestLong(long expected, byte[] source)
        {
            Test<LongConverter>(expected, source);
        }

        [Test]
        [TestCaseSource(typeof(BooleanConverterTestCaseSource))]
        public void TestBool(bool expected, byte[] source)
        {
            Test<BooleanConverter>(expected, source);
        }

        protected void Test<TConverter>(object expected, byte[] source) where TConverter : IConverter, new()
        {
            var stream = new MemoryStream(source);
            Assert.AreEqual(expected, new TConverter().Read(stream).Value);
        }
    }
}