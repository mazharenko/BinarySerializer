using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySerializer.Extensions
{
    internal static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var element in source)
            {
                action(element);
            }
        }

        public static IEnumerable<T> AsEnumerable<T>(this T source)
        {
            return Enumerable.Repeat(source, 1);
        }
    }
}