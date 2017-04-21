using System;

namespace BinarySerializer.Extensions
{
    internal static class TypeExtensions
    {
        public static object Default(this Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);
            return null;
        }
        
    }
}