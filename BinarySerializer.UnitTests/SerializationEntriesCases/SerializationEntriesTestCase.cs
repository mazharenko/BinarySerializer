using System.Collections.Generic;
using System.Runtime.Serialization;
using BinarySerializer.Serialization.Entries;
using NUnit.Framework;

namespace BinarySerializer.UnitTests.SerializationEntriesCases
{
    public class SerializationEntriesTestCase : TestCaseData
    {
        public SerializationEntriesTestCase(string name, object source, List<ISerializationStreamEntry> exptected)
            : base(source, exptected)
        {
            TestName = $"TestEntries{name}";
        }
    }
}