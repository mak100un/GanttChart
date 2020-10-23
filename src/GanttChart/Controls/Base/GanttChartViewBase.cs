using GanttChart.Models;
using SkiaSharp;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GanttChart.Controls.Base
{
    public abstract class GanttChartViewBase<TGanttSection, TGanttEntry> : ContentView
        where TGanttSection : GanttSection
        where TGanttEntry : GanttEntry
    {
        //-------------------------- Size Props -------------------------//

        #region Sizes



        /// <summary>
        /// StyleWeight of header text
        /// </summary>
        public SKFontStyleWeight HeaderTextStyleWeight
        {
            get => (SKFontStyleWeight)GetValue(HeaderTextStyleWeightProperty);
            set => SetValue(HeaderTextStyleWeightProperty, value);
        }

        public static readonly BindableProperty HeaderTextStyleWeightProperty = BindableProperty.Create
        (
           propertyName: nameof(HeaderTextStyleWeight),
           returnType: typeof(SKFontStyleWeight),
           declaringType: typeof(GanttChartView),
           defaultValue: SKFontStyleWeight.Bold
        );


        /// <summary>
        /// Height of chart
        /// <para>Value shold be calcilated by</para>
        /// <code>EntriesSource.Sum(e => e.RawHeight + SeparatorLineHeight) + (SubHeadersSource.IsEmpty() ? HeaderHeight + SeparatorLineHeight : HeaderHeight + SubHeaderHeight + SeparatorLineHeight);</code>
        /// </summary>
        public float ChartHeight
        {
            get => (float)GetValue(ChartHeightProperty);
            set => SetValue(ChartHeightProperty, value);
        }

        public static readonly BindableProperty ChartHeightProperty = BindableProperty.Create
        (
           propertyName: nameof(ChartHeight),
           returnType: typeof(float),
           declaringType: typeof(GanttChartView),
           defaultValue: default
        );



        /// <summary>
        /// Detail section width
        /// </summary>
        public float DetailWidth
        {
            get => (float)GetValue(DetailWidthProperty);
            set => SetValue(DetailWidthProperty, value);
        }

        public static readonly BindableProperty DetailWidthProperty = BindableProperty.Create
        (
           propertyName: nameof(DetailWidth),
           returnType: typeof(float),
           declaringType: typeof(GanttChartView),
           defaultValue: 200f
        );




        /// <summary>
        /// Height of detail headercell
        /// <code><see cref="HeaderHeight"/> + <see cref="SubHeaderHeight"/></code>
        /// </summary>
        public float DetailHeaderCellHeight
        {
            get => (float)GetValue(DetailHeaderCellHeightProperty);
            set => SetValue(DetailHeaderCellHeightProperty, value);
        }

        public static readonly BindableProperty DetailHeaderCellHeightProperty = BindableProperty.Create
        (
           propertyName: nameof(DetailHeaderCellHeight),
           returnType: typeof(float),
           declaringType: typeof(GanttChartView),
           defaultValue: default
        );



        /// <summary>
        /// Size of header text
        /// </summary>
        public float HeaderTextSize
        {
            get => (float)GetValue(HeaderTextSizeProperty);
            set => SetValue(HeaderTextSizeProperty, value);
        }

        public static readonly BindableProperty HeaderTextSizeProperty = BindableProperty.Create
        (
           propertyName: nameof(HeaderTextSize),
           returnType: typeof(float),
           declaringType: typeof(GanttChartView),
           defaultValue: 16f
        );



        /// <summary>
        /// Size of subheader text
        /// </summary>
        public float SubHeaderTextSize
        {
            get => (float)GetValue(SubHeaderTextSizeProperty);
            set => SetValue(SubHeaderTextSizeProperty, value);
        }

        public static readonly BindableProperty SubHeaderTextSizeProperty = BindableProperty.Create
        (
           propertyName: nameof(SubHeaderTextSize),
           returnType: typeof(float),
           declaringType: typeof(GanttChartView),
           defaultValue: 14f
        );



        /// <summary>
        /// StyleWeight of subheader text
        /// </summary>
        public SKFontStyleWeight SubHeaderTextStyleWeight
        {
            get => (SKFontStyleWeight)GetValue(SubHeaderTextStyleWeightProperty);
            set => SetValue(SubHeaderTextStyleWeightProperty, value);
        }

        public static readonly BindableProperty SubHeaderTextStyleWeightProperty = BindableProperty.Create
        (
           propertyName: nameof(SubHeaderTextStyleWeight),
           returnType: typeof(SKFontStyleWeight),
           declaringType: typeof(GanttChartView),
           defaultValue: SKFontStyleWeight.Normal
        );



        /// <summary>
        /// Height of header
        /// </summary>
        public float HeaderHeight
        {
            get => (float)GetValue(HeaderHeightProperty);
            set => SetValue(HeaderHeightProperty, value);
        }

        public static readonly BindableProperty HeaderHeightProperty = BindableProperty.Create
        (
           propertyName: nameof(HeaderHeight),
           returnType: typeof(float),
           declaringType: typeof(GanttChartView),
           defaultValue: 32f
        );



        /// <summary>
        /// Height of subheader
        /// </summary>
        public float SubHeaderHeight
        {
            get => (float)GetValue(SubHeaderHeightProperty);
            set => SetValue(SubHeaderHeightProperty, value);
        }

        public static readonly BindableProperty SubHeaderHeightProperty = BindableProperty.Create
        (
           propertyName: nameof(SubHeaderHeight),
           returnType: typeof(float),
           declaringType: typeof(GanttChartView),
           defaultValue: 32f
        );


        /// <summary>
        /// Height of separator line
        /// </summary>
        public float SeparatorLineHeight
        {
            get => (float)GetValue(SeparatorLineHeightProperty);
            set => SetValue(SeparatorLineHeightProperty, value);
        }

        public static readonly BindableProperty SeparatorLineHeightProperty = BindableProperty.Create
        (
           propertyName: nameof(SeparatorLineHeight),
           returnType: typeof(float),
           declaringType: typeof(GanttChartView),
           defaultValue: 1f
        );

        #endregion

        //-------------------------- Color Props -------------------------//

        #region Colors


        /// <summary>
        /// Style for detail header label
        /// </summary>
        public Color DetailBackgroundColor
        {
            get => (Color)GetValue(DetailBackgroundColorProperty);
            set => SetValue(DetailBackgroundColorProperty, value);
        }

        public static readonly BindableProperty DetailBackgroundColorProperty = BindableProperty.Create
        (
           propertyName: nameof(DetailBackgroundColor),
           returnType: typeof(Color),
           declaringType: typeof(GanttChartView),
           defaultValue: default
        );






        /// <summary>
        /// Style for detail header label
        /// </summary>
        public Style DetailHeaderTextStyle
        {
            get => (Style)GetValue(DetailHeaderTextStyleProperty);
            set => SetValue(DetailHeaderTextStyleProperty, value);
        }

        public static readonly BindableProperty DetailHeaderTextStyleProperty = BindableProperty.Create
        (
           propertyName: nameof(DetailHeaderTextStyle),
           returnType: typeof(Style),
           declaringType: typeof(GanttChartView),
           defaultValue: default
        );




        /// <summary>
        /// Style for entry detail label
        /// </summary>
        public Style GanttEntryDetailStyle
        {
            get => (Style)GetValue(GanttEntryDetailStyleProperty);
            set => SetValue(GanttEntryDetailStyleProperty, value);
        }

        public static readonly BindableProperty GanttEntryDetailStyleProperty = BindableProperty.Create
        (
           propertyName: nameof(GanttEntryDetailStyle),
           returnType: typeof(Style),
           declaringType: typeof(GanttChartView),
           defaultValue: default
        );



        /// <summary>
        /// Separator line
        /// </summary>
        public Color SeparatorLineColor
        {
            get => (Color)GetValue(SeparatorLineColorProperty);
            set => SetValue(SeparatorLineColorProperty, value);
        }

        public static readonly BindableProperty SeparatorLineColorProperty = BindableProperty.Create
        (
           propertyName: nameof(SeparatorLineColor),
           returnType: typeof(Color),
           declaringType: typeof(GanttChartView),
           defaultValue: default
        );



        /// <summary>
        /// Color of header text
        /// </summary>
        public Color HeaderTextColor
        {
            get => (Color)GetValue(HeaderTextColorProperty);
            set => SetValue(HeaderTextColorProperty, value);
        }

        public static readonly BindableProperty HeaderTextColorProperty = BindableProperty.Create
        (
           propertyName: nameof(HeaderTextColor),
           returnType: typeof(Color),
           declaringType: typeof(GanttChartView),
           defaultValue: default
        );



        /// <summary>
        /// Color of subheader text
        /// </summary>
        public Color SubHeaderTextColor
        {
            get => (Color)GetValue(SubHeaderTextColorProperty);
            set => SetValue(SubHeaderTextColorProperty, value);
        }

        public static readonly BindableProperty SubHeaderTextColorProperty = BindableProperty.Create
        (
           propertyName: nameof(SubHeaderTextColor),
           returnType: typeof(Color),
           declaringType: typeof(GanttChartView),
           defaultValue: default
        );



        /// <summary>
        /// Color of header
        /// </summary>
        public Color HeaderCellColor
        {
            get => (Color)GetValue(HeaderCellColorProperty);
            set => SetValue(HeaderCellColorProperty, value);
        }

        public static readonly BindableProperty HeaderCellColorProperty = BindableProperty.Create
        (
           propertyName: nameof(HeaderCellColor),
           returnType: typeof(Color),
           declaringType: typeof(GanttChartView),
           defaultValue: default
        );



        /// <summary>
        /// Color of subheader
        /// </summary>
        public Color SubHeaderCellColor
        {
            get => (Color)GetValue(SubHeaderCellColorProperty);
            set => SetValue(SubHeaderCellColorProperty, value);
        }

        public static readonly BindableProperty SubHeaderCellColorProperty = BindableProperty.Create
        (
           propertyName: nameof(SubHeaderCellColor),
           returnType: typeof(Color),
           declaringType: typeof(GanttChartView),
           defaultValue: default
        );


        #endregion


        /// <summary>
        /// ForceRedraw
        /// </summary>
        public static readonly BindableProperty ForceRedrawProperty = BindableProperty.Create
        (
            propertyName: nameof(ForceRedraw),
            returnType: typeof(bool),
            declaringType: typeof(GanttChartView),
            defaultValue: default,
            defaultBindingMode: default
        );

        public bool ForceRedraw
        {
            get => (bool)GetValue(ForceRedrawProperty);
            set => SetValue(ForceRedrawProperty, value);
        }


        /// <summary>
        /// Elements that need to be displayed in Gantt Chart in current section
        /// </summary>
        public static readonly BindableProperty GanttSectionsProperty = BindableProperty.Create
        (
            propertyName: nameof(GanttSections),
            returnType: typeof(ObservableCollection<TGanttSection>),
            declaringType: typeof(GanttChartView),
            defaultValue: default,
            defaultBindingMode: BindingMode.OneWay
        );

        public ObservableCollection<TGanttSection> GanttSections
        {
            get => (ObservableCollection<TGanttSection>)GetValue(GanttSectionsProperty);
            set => SetValue(GanttSectionsProperty, value);
        }

        /// <summary>
        /// Elements that need to be displayed in Gantt Chart in current section
        /// </summary>
        public static readonly BindableProperty EntriesProperty = BindableProperty.Create
        (
            propertyName: nameof(Entries),
            returnType: typeof(ObservableCollection<TGanttEntry>),
            declaringType: typeof(GanttChartView),
            defaultValue: default,
            defaultBindingMode: BindingMode.OneWay
        );

        public ObservableCollection<TGanttEntry> Entries
        {
            get => (ObservableCollection<TGanttEntry>)GetValue(EntriesProperty);
            set => SetValue(EntriesProperty, value);
        }
    }
}
