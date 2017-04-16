using System;
using BinarySerializer.UnitTests.Contracts;
using NUnit.Framework;

namespace BinarySerializer.UnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestObject()
        {
            var c = new ComplexObject
            {
                IgnoredInt = 30,
                ComplexObject2 = new ComplexObject2
                {
                    Class1 = new Class1
                    {
                        Boolean = true,
                        BooleanField = true
                    },
                    Integer = -421
                }
            };

            ContractSerializer.Serialize(c);

            var v = new WithoutAppropriateMembers();


            ContractSerializer.Serialize(v);
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(typeof(Enum).IsAssignableFrom(typeof(A)));

        }

        enum A
        {
            d,
            b
        }
    }
}