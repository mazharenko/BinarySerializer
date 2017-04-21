using BinarySerializer.UnitTests.Contracts;
using NUnit.Framework;

namespace BinarySerializer.UnitTests
{
    [TestFixture]
    public class EmptyObjectsTests
    {
        [Test]
        public void TestEmpty()
        {
            var empty = new Empty();

            var bytes = ContractSerializer.Serialize(empty);

            CollectionAssert.IsEmpty(bytes);

            var deserialized = ContractSerializer.Deserialize<Empty>(bytes);

            Assert.IsNotNull(deserialized);
            Assert.IsInstanceOf<Empty>(deserialized);
        }
    }
}