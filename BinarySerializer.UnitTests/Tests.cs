using NUnit.Framework;

namespace BinarySerializer.UnitTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Test2()
        {
            var d = ContractSerializer.Serialize(45);
        }

        enum A
        {
            d,
            b
        }
    }
}