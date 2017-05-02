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
            var bytes = ContractSerializer.Serialize(new Empty());

            Assert.AreEqual(new byte[0], bytes);

            var deserialized = ContractSerializer.Deserialize<Empty>(bytes);

            Assert.IsNotNull(deserialized);
            Assert.IsInstanceOf(typeof(Empty), deserialized);
        }


        [Test]
        public void TestEmptyHolderNull()
        {
            var bytes = ContractSerializer.Serialize(new EmptyHolder
            {
                Empty = null
            });

            Assert.AreEqual(new byte[0], bytes);

            var deserialized = ContractSerializer.Deserialize<EmptyHolder>(bytes);

            Assert.IsNotNull(deserialized);
            Assert.IsInstanceOf(typeof(EmptyHolder), deserialized);
        }

        [Test]
        public void TestEmptyHolder()
        {
            var bytes = ContractSerializer.Serialize(new EmptyHolder());

            Assert.AreEqual(new byte[] {228, 128}, bytes);

            var deserialized = ContractSerializer.Deserialize<EmptyHolder>(bytes);

            Assert.IsNotNull(deserialized);
            Assert.IsInstanceOf(typeof(EmptyHolder), deserialized);
        }

        [Test]
        public void TestEmptyHolderDouble()
        {
            var bytes = ContractSerializer.Serialize(new EmptyHolder
            {
                SubHolder = new EmptySubHolder()
            });

            Assert.AreEqual(new byte[] {229, 228, 128, 128, 228, 128}, bytes);

            var deserialized = ContractSerializer.Deserialize<EmptyHolder>(bytes);

            Assert.IsNotNull(deserialized);
            Assert.IsInstanceOf(typeof(EmptyHolder), deserialized);
        }

        [Test]
        public void TestEmptyHolderDoubleNull()
        {
            var bytes = ContractSerializer.Serialize(new EmptyHolder
            {
                SubHolder = new EmptySubHolder
                {
                    Empty = null
                }
            });

            Assert.AreEqual(new byte[] {229, 128, 228, 128}, bytes);

            var deserialized = ContractSerializer.Deserialize<EmptyHolder>(bytes);

            Assert.IsNotNull(deserialized);
            Assert.IsInstanceOf(typeof(EmptyHolder), deserialized);
        }
    }
}