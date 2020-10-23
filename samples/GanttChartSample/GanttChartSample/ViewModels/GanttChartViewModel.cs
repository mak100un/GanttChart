using GanttChart.Extensions;
using GanttChart.Models;
using GanttChartSample.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GanttChartSample.ViewModels
{
    public class GanttChartViewModel : GanttViewModelBase<GanttSection, GanttEntry>
    {
        #region subsections 

        private readonly ObservableCollection<string> _months = new ObservableCollection<string>
        {
            "Jan.",
            "Feb.",
            "March",
            "April",
            "May",
            "June",
            "July",
            "Aug.",
            "Sep.",
            "Oct.",
            "Nov.",
            "Dec."
        };

        #endregion

        public override Color ImplementationColor => Color.DarkViolet;
        public override Color RemainingColor => Color.LightSlateGray;

        public override float RawHeight => 98;
        public override float IndicatorHeight => 20;
        public override float SeparatorLineHeight => 1;
        public override float SubHeaderHeight => 32;
        public override float ColumnWidth => WithSubHeaders ? 50 : 80;
        public override float HeaderHeight => 38;

        public bool IsRefreshing { get; set; }
        public ICommand RefreshCommand { get; }
        public ICommand ChangeSectionCommand { get; }

        public GanttChartViewModel()
        {
            Title = "Gantt Chart Sample";
            RefreshCommand = new Command(RefreshAsync);
            ChangeSectionCommand = new Command(ChangeSectionAsync);
            Entries = GetEntries();
        }

        private void ChangeSectionAsync()
            => SubHeaders = WithSubHeaders ? null : _months;
        // Change Year Chart to Month or Vice versa

        private async void RefreshAsync()
        {
            IsRefreshing = true;
            Entries = null;
            await Task.Delay(100); //Send request to server
            Entries = GetEntries();
            IsRefreshing = false;
        }

        /// <summary>
        /// Works that have been executed or planning to be done in the furute
        /// </summary>
        /// <returns></returns>
        protected override ObservableCollection<GanttEntry> GetEntries()
            => new ObservableCollection<GanttEntry>
            {
                new GanttEntry
                {
                    Start = (0, 8 / (float)_months.Count), //Complete 8 months
                    Implementation = (3, 6 / (float)_months.Count),
                    Remaining = (3, 6 / (float)_months.Count),
                    ImplementationColor = ImplementationColor,
                    RemainingColor = RemainingColor,
                    IndicatorHeight = IndicatorHeight,
                    RawHeight = RawHeight,
                    Name = "Learn C#"
                },
                new GanttEntry
                {
                    Start = (3, 6 / (float)_months.Count),
                    Implementation = (4, 8 / (float)_months.Count),
                    Remaining = (4, 8 / (float)_months.Count),
                    ImplementationColor = ImplementationColor,
                    RemainingColor = RemainingColor,
                    IndicatorHeight = IndicatorHeight,
                    RawHeight = RawHeight,
                    Name = "Learn Xamarin"
                },
                new GanttEntry
                {
                    Start = (3, 8 / (float)_months.Count),
                    Implementation = (4, 8 / (float)_months.Count),
                    Remaining = (4, 8 / (float)_months.Count),
                    ImplementationColor = ImplementationColor,
                    RemainingColor = RemainingColor,
                    IndicatorHeight = IndicatorHeight,
                    RawHeight = RawHeight,
                    Name = "Learn ASP.NET Core"
                },
                new GanttEntry
                {
                    Start = (4, 8 / (float)_months.Count),
                    Implementation = (5, 10 / (float)_months.Count),
                    Remaining = (6, 1),
                    ImplementationColor = ImplementationColor,
                    RemainingColor = RemainingColor,
                    IndicatorHeight = IndicatorHeight,
                    RawHeight = RawHeight + 50,
                    Name = "Practise in C#, Xamarin, ASP.NET Core"
                },
                new GanttEntry
                {
                    Start = (5, 6 / (float)_months.Count),
                    Implementation = (5, 7 / (float)_months.Count),
                    Remaining = (5, 7 / (float)_months.Count),
                    ImplementationColor = ImplementationColor,
                    RemainingColor = RemainingColor,
                    IndicatorHeight = IndicatorHeight,
                    RawHeight = RawHeight,
                    Name = "Learn Kotlin"
                },
                new GanttEntry
                {
                    Start = (5, 8 / (float)_months.Count),
                    Implementation = (5, 9 / (float)_months.Count),
                    Remaining = (5, 9 / (float)_months.Count),
                    ImplementationColor = ImplementationColor,
                    RemainingColor = RemainingColor,
                    IndicatorHeight = IndicatorHeight,
                    RawHeight = RawHeight,
                    Name = "Learn Swift"
                },
                new GanttEntry
                {
                    Start = (5, 9 / (float)_months.Count),
                    Implementation = (5, 10 / (float)_months.Count),
                    Remaining = (5, 11 / (float)_months.Count),
                    ImplementationColor = ImplementationColor,
                    RemainingColor = RemainingColor,
                    IndicatorHeight = IndicatorHeight,
                    RawHeight = RawHeight,
                    Name = "Learn Android"
                }
            };

        protected override ObservableCollection<GanttSection> GetSections()
            => Enumerable.Range(2015, 8)
            .Select((y, i) => new GanttSection
            {
                ColumnWidth = WithSubHeaders
                ? (ColumnWidth + SeparatorLineHeight) * SubHeaders.Count - SeparatorLineHeight
                : ColumnWidth,
                ColumnWidthWithSeparator = WithSubHeaders
                ? (ColumnWidth + SeparatorLineHeight) * SubHeaders.Count
                : (ColumnWidth + SeparatorLineHeight),
                Order = i,
                SectionName = y.ToString(),
                SubHeaders = SubHeaders
            })
            .ToObservableCollection();
    }
}
