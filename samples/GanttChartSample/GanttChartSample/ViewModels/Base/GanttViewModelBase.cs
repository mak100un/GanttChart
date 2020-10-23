using GanttChart.Extensions;
using GanttChart.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace GanttChartSample.ViewModels.Base
{
    public abstract class GanttViewModelBase<TGanttSection, TGanttEntry> : ViewModelBase
        where TGanttSection : GanttSection
        where TGanttEntry : GanttEntry
    {
        public abstract Color ImplementationColor { get; }
        public abstract Color RemainingColor { get; }

        public bool WithSubHeaders => !SubHeaders.IsEmpty();
        public ObservableCollection<string> SubHeaders { get; protected set; }


        public ObservableCollection<TGanttSection> GanttSections
            => WithSubHeaders  //In order to update layout
            ? GetSections()
            : GetSections();
        public ObservableCollection<TGanttEntry> Entries { get; protected set; }

        public float ChartHeight => Entries.IsEmpty()
            ? DetailHeaderCellHeight + SeparatorLineHeight
            : Entries.Sum(e => e.RawHeight + SeparatorLineHeight) + DetailHeaderCellHeight + SeparatorLineHeight;

        public abstract float RawHeight { get; }
        public abstract float IndicatorHeight { get; }
        public abstract float SeparatorLineHeight { get; }
        public abstract float SubHeaderHeight { get; }
        public abstract float ColumnWidth { get; }
        public abstract float HeaderHeight { get; }
        public float DetailHeaderCellHeight => WithSubHeaders
            ? SubHeaderHeight + HeaderHeight + SeparatorLineHeight
            : HeaderHeight;
        protected abstract ObservableCollection<TGanttSection> GetSections();
        protected abstract ObservableCollection<TGanttEntry> GetEntries();

    }
}
