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

        [Test]
        public void Test2()
        {
            long d = unchecked((long)ulong.MaxValue);

            var b = (ulong) d;

            Assert.AreEqual(ulong.MaxValue, b);

            b = unchecked((ulong) long.MinValue);

            d = (long) b;

            Assert.AreEqual(long.MinValue, d);

        }
    }
}