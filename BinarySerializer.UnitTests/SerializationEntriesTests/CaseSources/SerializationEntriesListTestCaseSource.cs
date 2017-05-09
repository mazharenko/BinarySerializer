using System.Collections;
using System.Collections.Generic;
using BinarySerializer.Serialization.Entries;
using BinarySerializer.UnitTests.SerializationEntriesTests.Cases;
using Contracts;

namespace BinarySerializer.UnitTests.SerializationEntriesTests.CaseSources
{
    public class SerializationEntriesListTestCaseSource
    {
        public static IEnumerable GetSimpleCases()
        {
            yield return new SerializationEntriesTestCase("ListInt", new List<int>
            {
                17,
                94,
                255
            }, new List<ISerializationStreamEntry>
            {
                new ConvertationEntry(typeof(int), 3),
                new ConvertationEntry(typeof(int), 17),
                new ConvertationEntry(typeof(int), 94),
                new ConvertationEntry(typeof(int), 255)
            });
        }

        public static IEnumerable GetCombinedCases()
        {
            yield return new SerializationEntriesTestCase("ListCombined", new List<ListComplexObject>
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
                }, new List<ISerializationStreamEntry>
                {
                    new MemberHeaderEntry(1),
                    new MemberHeaderEntry(701),
                    new ConvertationEntry(typeof(int), 2),
                    new ConvertationEntry(typeof(int), 4),
                    new ConvertationEntry(typeof(int), 9),
                    new MemberEndingEntry(),
                    new MemberHeaderEntry(1),
                    new MemberHeaderEntry(701),
                    new ConvertationEntry(typeof(int), 3),
                    new ConvertationEntry(typeof(int), 7),
                    new ConvertationEntry(typeof(int), 0),
                    new ConvertationEntry(typeof(int), 341),
                    new MemberEndingEntry(),
                    new MemberHeaderEntry(1),
                    new MemberHeaderEntry(701),
                    new ConvertationEntry(typeof(int), 2),
                    new ConvertationEntry(typeof(int), -123),
                    new ConvertationEntry(typeof(int), 41),
                    new MemberEndingEntry()
                }
            );
        }


        public static IEnumerable GetEmptyCases()
        {
            yield return new SerializationEntriesTestCase("ListNestedEmpty", new ListComplexObject
            {
                ListInt = new List<int>(),
                ArrayInt = new int[0],
                ListComplex = new List<ListComplexObject>(),
                ArrayComplex = new ListComplexObject[0]
            }, new List<ISerializationStreamEntry>
            {
                new MemberHeaderEntry(701),
                new ConvertationEntry(typeof(int), 0),
                new MemberHeaderEntry(702),
                new ConvertationEntry(typeof(int), 0),
                new MemberHeaderEntry(703),
                new MemberEndingEntry(),
                new MemberHeaderEntry(704),
                new MemberEndingEntry(),
            });
            yield return new SerializationEntriesTestCase("ListIntEmpty", new List<int>(),
                new List<ISerializationStreamEntry>
                {
                    new ConvertationEntry(typeof(int), 0)
                });
            yield return new SerializationEntriesTestCase("ListComplexEmpty", new List<ListComplexObject>(),
                new List<ISerializationStreamEntry>
                {

                });
            yield return new SerializationEntriesTestCase("ListComplexNestedEmpty",
                new List<ListComplexObject> {new ListComplexObject()}, new List<ISerializationStreamEntry>
                {
                    new MemberHeaderEntry(1),
                    new MemberEndingEntry()
                });
        }
    }
}