using NUnit.Framework;

namespace BinarySerializer.UnitTests
{
    [TestFixture]
    public class EmptyObjectsTests
    {
        [Test]
        [TestCaseSource(typeof(EmptyTestCaseSource))]
        public void TestEmpty(object empty)
        {
            var bytes = ContractSerializer.Serialize(empty);

            Assert.AreEqual(new byte[] {129, 128}, bytes);

            var deserialized = ContractSerializer.Deserialize(empty.GetType(), bytes);

            Assert.IsNotNull(deserialized);
            Assert.IsInstanceOf(empty.GetType(), deserialized);
        }

    }

}