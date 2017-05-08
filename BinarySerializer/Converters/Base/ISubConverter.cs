using System;

namespace BinarySerializer.Converters.Base
{
    public interface ISubConverter : IConverterBase
    {
        Type SubType { get; }
        object Write(object source);
        object Read(object source);
    }
}