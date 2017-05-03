using BinarySerializer.UnitTests.SerializationTests.CaseSources;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.SerializationTests
{
    [TestFixture]
    public class DeserializationTests
    {
        [Test]
        [TestCaseSource(typeof(EmptyObjectsTestCaseSource))]
        [TestCaseSource(typeof(EmptyObjectsTestCaseSource), nameof(EmptyObjectsTestCaseSource.GetDeserializationOnlyCases))]
        [TestCaseSource(typeof(SingleObjectsTestCaseSource))]
        [TestCaseSource(typeof(ComplexObjectsTestCaseSource))]
        [TestCaseSource(typeof(ComplexObjectsTestCaseSource), nameof(ComplexObjectsTestCaseSource.GetDeserializationOnlyCases))]
        [TestCaseSource(typeof(ListTestCaseSource))]
        public void TestDeserialization(object expected, byte[] source)
        {
            var deserialized = ContractSerializer.Deserialize(expected.GetType(), source);

            Assert.AreEqual(expected, deserialized);
        }
    }
}