using System.Collections.Generic;
using BinarySerializer.UnitTests.Contracts;
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

            var o = ContractSerializer.Deserialize<int>(d);


            var complexObject = new ComplexObject
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

            var dd = ContractSerializer.Serialize(complexObject);

            var oo = ContractSerializer.Deserialize<ComplexObject>(dd);

        }

        [Test]
        public void TestList()
        {
            var l = new List<ListComplexObject>
            {
                new ListComplexObject
                {
                    ListInt = new List<int>
                    {
                        4,
                        9
                    }
                },
                new ListComplexObject
                {
                    ListInt = new List<int>
                    {
                        7,
                        0,
                        341
                    }
                },
                new ListComplexObject
                {
                    ListInt = new List<int>
                    {
                        -123,
                        41
                    }
                }
            };

            var d = ContractSerializer.Serialize(l);

            var ll = ContractSerializer.Deserialize<List<ListComplexObject>>(d);
        }

        enum A
        {
            d,
            b
        }
    }
}