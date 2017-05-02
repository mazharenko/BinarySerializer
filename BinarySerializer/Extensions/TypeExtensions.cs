using System;
using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Exceptions;

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

        public static object CreateContract(this Type type)
        {
            if (!ContractIsCreatable(type))
                throw new InvalidConfigurationException($"The specified type can't be instantiated - {type}");

            return Activator.CreateInstance(type);
        }

        public static bool ContractIsCreatable(this Type type)
        {
            return type.GetConstructor(new Type[0]) != null;
        }
    }
}