using System;
using System.Collections.Generic;
using System.Linq;

namespace GanttChart.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsEmpty<TType>(this IEnumerable<TType> collection)
            => collection == null || !collection.Any();

        public static void ForEach<TType>(this IEnumerable<TType> collection, Action<TType> action)
        {
            foreach (var element in collection)
                action(element);
        }
    }
}
