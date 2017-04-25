using System;
using System.Collections.Generic;

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
            yield return source;
        }
    }
}