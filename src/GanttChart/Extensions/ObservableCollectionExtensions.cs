using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GanttChart.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<TType> ToObservableCollection<TType>(this IEnumerable<TType> collection)
            => new ObservableCollection<TType>(collection);
    }
}
