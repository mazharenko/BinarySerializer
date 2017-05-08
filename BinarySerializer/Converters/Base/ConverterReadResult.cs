namespace BinarySerializer.Converters.Base
{
    public class ConverterReadResult
    {
        public object Value { get; set; }
        public bool StreamEndReached { get; set; }

        public static ConverterReadResult StreamEnd()
        {
            return new ConverterReadResult
            {
                StreamEndReached = true
            };
        }
    }
}