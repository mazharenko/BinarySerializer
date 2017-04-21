using System.Collections.Generic;
using System.IO;
using BinarySerializer.Extensions;
using BinarySerializer.Serialization;
using BinarySerializer.Serialization.Entries;
using BinarySerializer.Serialization.Stream;
using NUnit.Framework;
using Rhino.Mocks;

namespace BinarySerializer.UnitTests
{
    public abstract class SerializationEntriesTests
    {
        protected SerializationSettings Settings;

        [SetUp]
        public virtual void SetUp()
        {
            Settings = new SerializationSettings
            {
                StreamWriter = MockRepository.GenerateStrictMock<ISerializationStreamWriter>()
            };
        }

        protected void AssertSerializationEntries(object source, IEnumerable<ISerializationStreamEntry> expected)
        {
            expected.ForEach(
                e => Settings.StreamWriter.Expect(w => w.Write(Arg<ISerializationStreamEntry>
                        .Is.Equal(e), Arg<SerializationContext>.Matches(c => c.Settings == Settings)))
                    .Repeat.Once()
            );

            using (var stream = new MemoryStream())
                ContractSerializer.Serialize(source, stream, Settings);

            Settings.StreamWriter.VerifyAllExpectations();
        }
    }
}