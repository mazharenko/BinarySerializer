using System;
using System.Collections.Generic;
using System.Linq;

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

        // Только List??? Array просто так не создать
        public static Type GetIListImlementaionElementType(this Type sourceType)
        {
            if (sourceType.IsAbstract || sourceType.IsInterface)
                return null;
            return sourceType.GetInterfaces()
                .Concat(sourceType.AsEnumerable())
                .FirstOrDefault(i =>
                     i.IsConstructedGenericType
                    && !i.ContainsGenericParameters
                    && i.GetGenericTypeDefinition() == typeof(IList<>)
                )?.GetGenericArguments().Single();
        }
    }
}