using System.Collections;
using System.Collections.Generic;
using BinarySerializer.Serialization.Entries;
using BinarySerializer.UnitTests.Contracts;
using BinarySerializer.UnitTests.SerializationEntriesTests.Cases;

namespace BinarySerializer.UnitTests.SerializationEntriesTests.CaseSources
{
    public class SerializationEntriesComplexObjectTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SerializationEntriesTestCase("EmptyHolder", new EmptyHolder(),
                new List<ISerializationStreamEntry>
                {
                    new MemberHeaderEntry(100),
                    new MemberEndingEntry()
                });
            yield return new SerializationEntriesTestCase("GenericSimple", new Generic<int>
            {
                Parameter = 4
            }, new List<ISerializationStreamEntry>
            {
                new MemberHeaderEntry(1),
                new ConvertationEntry(typeof(int), 4)
            });

            yield return new SerializationEntriesTestCase("GenericDouble", new Generic<Generic<int>>
            {
                Parameter = new Generic<int>
                {
                    Parameter = -321
                }
            }, new List<ISerializationStreamEntry>
            {
                new MemberHeaderEntry(1),
                new MemberHeaderEntry(1),
                new ConvertationEntry(typeof(int), -321),
                new MemberEndingEntry()
            });

            yield return new SerializationEntriesTestCase("ComplexObject", new ComplexObject
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
            }, new List<ISerializationStreamEntry>
            {
                new MemberHeaderEntry(2),
                new MemberHeaderEntry(10),
                new MemberHeaderEntry(1),
                new ConvertationEntry(true),
                new MemberHeaderEntry(2),
                new ConvertationEntry(true),
                new MemberEndingEntry(),
                new MemberHeaderEntry(7),
                new ConvertationEntry(-421),
                new MemberEndingEntry()
            });
        }
    }
}