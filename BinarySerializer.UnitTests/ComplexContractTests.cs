using BinarySerializer.UnitTests.Contracts;
using NUnit.Framework;

namespace BinarySerializer.UnitTests
{
    [TestFixture]
    public class ComplexContractTests
    {
        private ComplexObject _complexObject;

        [SetUp]
        protected void SetUp()
        {
            _complexObject = new ComplexObject
            {
                IgnoredInt = 30,
                SubComplexObject = new SubComplexObject
                {
                    Boolean = new BooleanObject
                    {
                        Boolean = true,
                        BooleanField = true
                    },
                    Integer = -421
                }
            };
        }

        [Test]
        public void Test1()
        {
            var dd = ContractSerializer.Serialize(_complexObject);

            var o = ContractSerializer.Deserialize<ComplexObject>(dd);
        }
    }
}