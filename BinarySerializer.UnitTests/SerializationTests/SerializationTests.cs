using BinarySerializer.UnitTests.Contracts;
using BinarySerializer.UnitTests.SerializationTests.CaseSources;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.SerializationTests
{
    [TestFixture]
    public class SerializationTests
    {
        [Test]
        [TestCaseSource(typeof(EmptyObjectsTestCaseSource))]
        [TestCaseSource(typeof(EmptyObjectsTestCaseSource), nameof(EmptyObjectsTestCaseSource.GetSerializationOnlyCases))]
        [TestCaseSource(typeof(SingleObjectsTestCaseSource))]
        [TestCaseSource(typeof(ComplexObjectsTestCaseSource))]
        [TestCaseSource(typeof(ComplexObjectsTestCaseSource), nameof(ComplexObjectsTestCaseSource.GetSerializationOnlyCases))]
        [TestCaseSource(typeof(ListTestCaseSource))]
        public void TestSerialization(object source, byte[] expected)
        {
            var bytes = ContractSerializer.Serialize(source);

            Assert.AreEqual(expected, bytes);
        }
    }
}