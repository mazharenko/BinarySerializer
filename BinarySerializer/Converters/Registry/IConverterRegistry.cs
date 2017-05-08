using System;
using BinarySerializer.Converters.Base;

namespace BinarySerializer.Converters.Registry
{
    public interface IConverterRegistry
    {
        void AddConverter(IConverter converter);
        void AddConverter(ISubConverter converter);
        IConverter GetConverter(Type type);
    }
}