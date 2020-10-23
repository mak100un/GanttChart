using GanttChart.Controls.Base;
using GanttChart.Models;
using Xamarin.Forms.Xaml;

namespace GanttChart.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GanttChartView : GanttChartViewBase<GanttSection, GanttEntry>
    {
        public GanttChartView() => InitializeComponent();
    }
}