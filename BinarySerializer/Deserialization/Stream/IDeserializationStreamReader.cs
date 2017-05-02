using System.Collections.Generic;
using BinarySerializer.Adapters;

namespace BinarySerializer.Deserialization.Stream
{
    public interface IDeserializationStreamReader
    {
        void Read(/*ObjectAdapter objectAdapter,*/ ContractMemberAdapter members, DeserializationContext context);
    }
}