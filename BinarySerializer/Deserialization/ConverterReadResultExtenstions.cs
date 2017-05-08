using BinarySerializer.Converters;
using BinarySerializer.Converters.Base;
using BinarySerializer.Exceptions;

namespace BinarySerializer.Deserialization
{
    public static class ConverterReadResultExtenstions
    {
        public static object ExtractValue(this ConverterReadResult readResult)
        {
            object result;
            if (!ExtractValue(readResult, out result))
                throw new UnexpectedStreamEndException();
            return result;
        }

        public static bool ExtractValue(this ConverterReadResult readResult,
            out object value)
        {
            value = readResult.Value;
            return !readResult.StreamEndReached;
        }
    }
}