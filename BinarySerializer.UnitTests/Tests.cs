using System;
using BinarySerializer.UnitTests.Contracts;
using NUnit.Framework;

namespace BinarySerializer.UnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
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
                    }
                },
                String = "dddfd"
            };

            ContractSerializer.Serialize(c);

            var v = new WithoutAppropriateMembers();


            ContractSerializer.Serialize(v);
        }
    }
}