using System.Collections.Generic;
using BinarySerializer.Serialization.Entries;
using BinarySerializer.UnitTests.Contracts;
using NUnit.Framework;

namespace BinarySerializer.UnitTests
{
    [TestFixture]
    public class GenericTests : SerializationEntriesTests
    {
        [Test]
        public void TestGenericSimple()
        {
            var g = new Generic<int>
            {
                Parameter = 4
            };

            AssertSerializationEntries(g,
                new List<ISerializationStreamEntry>
                {
                    new MemberHeaderEntry(1),
                    new ConvertationEntry(typeof(int), 4)
                });
        }


        [Test]
        public void TestGenericDouble()
        {
            var g = new Generic<Generic<int>>
            {
                Parameter = new Generic<int>
                {
                    Parameter = -321
                }
            };

            AssertSerializationEntries(g,
                new List<ISerializationStreamEntry>
                {
                    new MemberHeaderEntry(1),
                    new MemberHeaderEntry(1),
                    new ConvertationEntry(typeof(int), -321),
                    new MemberEndingEntry()
                });
        }
    }
}