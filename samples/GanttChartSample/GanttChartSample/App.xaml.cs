using GanttChartSample.Views;
using Xamarin.Forms;

namespace GanttChartSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new GanttChartPage();
        }
    }
}
