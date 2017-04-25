using BinarySerializer.Converters;
using BinarySerializer.Exceptions;

namespace BinarySerializer.Deserialization.Executors
{
    public class MemberExecutorBase
    {
        protected static object ExtractValueFromReadResult(ConverterReadResult readResult)
        {
            bool streamEndReached;
            var result = ExtractValueFromReadResult(readResult, out streamEndReached);
            if (streamEndReached)
                throw new UnexpectedStreamEndException();
            return result;
        }

        protected static object ExtractValueFromReadResult(ConverterReadResult readResult, out bool streamEndReached)
        {
            streamEndReached = readResult.StreamEndReached;
            return readResult.Value;
        }

    }
}