using System.Collections.ObjectModel;

namespace GanttChart.Models
{
    public class GanttSection
    {
        /// <summary>
        /// Name of section 
        /// <para>(Maybe Year or Moth)</para>
        /// </summary>
        /// <summary>
        /// Section name
        /// <para>Will be displayed in header cell</para>
        /// </summary>
        public string SectionName { get; set; }



        /// <summary>
        /// Section Order
        /// </summary>
        public int Order { get; set; }



        /// <summary>
        /// Sub headers of current section
        /// </summary>
        public ObservableCollection<string> SubHeaders { get; set; }



        /// <summary>
        /// Width of column witht <see cref="SeparatorLineHeight"/>
        /// </summary>
        public float ColumnWidthWithSeparator { get; set; } = 70f;


        /// <summary>
        /// Width of column without <see cref="SeparatorLineHeight"/>
        /// </summary>
        public float ColumnWidth { get; set; } = 70f;

    }
}
