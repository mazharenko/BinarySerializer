using System;

namespace BinarySerializer
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