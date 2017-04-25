using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Adapters;
using BinarySerializer.Deserialization.Executors;
using BinarySerializer.Exceptions;

namespace BinarySerializer.Deserialization.Stream
{
    internal class DeserializationExecutorRegistry : IDeserializationExecutorRegistry
    {
        protected readonly List<IDeserializationExecutor> Executors = new List<IDeserializationExecutor>
        {
            new ConvertingDeserializationExecutor()
        };

        public IDeserializationExecutor GetExecutor(ContractMemberAdapter memberAdapter,
            DeserializationContext serializationContext)
        {
            var executor = Executors.FirstOrDefault(s => s.GetIsApplicable(memberAdapter, serializationContext));
      //      if (executor == null)
      //          throw new InvalidMemberException(memberAdapter);
            return executor;
        }
    }
}