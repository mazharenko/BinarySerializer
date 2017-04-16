using System.IO;
using BinarySerializer.Writers.Converters;
using BinarySerializer.Writers.Converters.Integer;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.ConverterTests
{
    [TestFixture]
    public class ConverterTests
    {
        [Test]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetInt32Cases))]
        public void TestInteger(int source, byte[] expected)
        {
            Test<IntConverter>(source, expected);
        }

        [Test]
        [TestCaseSource(typeof(IntegerConverterTestCaseSource), nameof(IntegerConverterTestCaseSource.GetLongCases))]
        public void TestLong(long source, byte[] expected)
        {
            Test<LongConverter>(source, expected);
        }

        [Test]
        [TestCaseSource(typeof(BooleanConverterTestCaseSource))]
        public void TestBool(bool source, byte[] expected)
        {
            Test<BooleanConverter>(source, expected);
        }

        protected void Test<TConverter>(object source, byte[] expected) where TConverter : IConverter, new()
        {
            var stream = new MemoryStream();
            new TConverter().Write(source, stream);
            CollectionAssert.AreEqual(expected, stream.ToArray());
        }
    }
}