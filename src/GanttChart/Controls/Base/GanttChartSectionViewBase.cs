using GanttChart.Extensions;
using GanttChart.Models;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace GanttChart.Controls.Base
{
    public abstract class GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry> : SKCanvasView
        where TGanttSectionEntry : GanttSectionEntry, new()
        where TGanttEntry : GanttEntry
    {
        public GanttChartSectionViewBase()
            => PaintSurface += OnGanttChartViewPaintSurface; // Subscribe on canvas redrawning

        private void OnGanttChartViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
            => OnChartDraw(e);


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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
           defaultValue: SKFontStyleWeight.Bold
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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
           defaultValue: 1f
        );


        /// <summary>
        /// Fullcolumn width
        /// </summary>
        public float ColumnWidthWithSeparator => ColumnWidth + SeparatorLineHeight;

        /// <summary>
        /// Width of column without <see cref="SeparatorLineHeight"/>
        /// </summary>
        public float ColumnWidth
        {
            get => (float)GetValue(ColumnWidthProperty);
            set => SetValue(ColumnWidthProperty, value);
        }

        public static readonly BindableProperty ColumnWidthProperty = BindableProperty.Create
        (
           propertyName: nameof(ColumnWidth),
           returnType: typeof(float),
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
           defaultValue: 70f
        );


        /// <summary>
        /// Width of subcolumns
        /// </summary>
        private float SubColumnWidth => SubHeadersSource.IsEmpty()
            ? 0
            : ColumnWidthWithSeparator / SubHeadersSource.Count - SeparatorLineHeight;

        #endregion

        //-------------------------- Color Props -------------------------//

        #region Colors

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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
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
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
           defaultValue: default
        );


        #endregion


        //-------------------------- Source Props -------------------------//

        #region Source



        /// <summary>
        /// Section name
        /// <para>Will be displayed in header cell</para>
        /// </summary>
        public string SectionName
        {
            get => (string)GetValue(SectionNameProperty);
            set => SetValue(SectionNameProperty, value);
        }

        public static readonly BindableProperty SectionNameProperty = BindableProperty.Create
        (
           propertyName: nameof(SectionName),
           returnType: typeof(string),
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
           defaultValue: default
        );



        /// <summary>
        /// Section Order
        /// </summary>
        public int Order
        {
            get => (int)GetValue(OrderProperty);
            set => SetValue(OrderProperty, value);
        }

        public static readonly BindableProperty OrderProperty = BindableProperty.Create
        (
           propertyName: nameof(Order),
           returnType: typeof(int),
           declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
           defaultValue: default,
           propertyChanged: (b, oV, nV) => OrderChanged(b, nV)
        );

        private static void OrderChanged(BindableObject bindable, object newValue)
        {
            if (!(bindable is GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry> gantChartSection))
                return;

            if (!(newValue is int order))
                return;

            CreateSectionEntries(gantChartSection, order, gantChartSection.EntriesSource);
        }

        /// <summary>
        /// Create section entries after order of section or entries was set
        /// </summary>
        /// <param name="gantChartSection"></param>
        /// <param name="order"></param>
        /// <param name="entries"></param>
        private static void CreateSectionEntries
        (
            GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry> gantChartSection,
            int order,
            ObservableCollection<TGanttEntry> entries
        )
            => gantChartSection.SectionEntries = entries
            ?.Select(e => gantChartSection.MapToSectionEntry(order, e))
            ?.ToObservableCollection();


        protected virtual TGanttSectionEntry MapToSectionEntry
        (
            int order,
            TGanttEntry entry
        )
            => new TGanttSectionEntry
            {
                Implementation = entry.Implementation.Section > order && entry.Start.Section <= order
                    ? 1
                    : entry.Implementation.Section != order
                    ? 0
                    : entry.Implementation.Percent,
                RemainingColor = entry.RemainingColor,
                ImplementationColor = entry.ImplementationColor,
                IndicatorHeight = entry.IndicatorHeight,
                RawHeight = entry.RawHeight,
                Remaining = entry.Remaining.Section == order
                    ? entry.Remaining.Percent
                    : entry.Remaining.Section > order && entry.Start.Section <= order
                    ? 1
                    : 0,
                Start = entry.Start.Section == order
                    ? entry.Start.Percent
                    : 0
            };

        /// <summary>
        /// Sub headers that will be displayed under each header
        /// </summary>
        public static readonly BindableProperty SubHeadersSourceProperty = BindableProperty.Create
        (
            propertyName: nameof(SubHeadersSource),
            returnType: typeof(ObservableCollection<string>),
            declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
            defaultValue: default,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: (b, oV, nV) => SubHeadersSourceChanged(b, oV, nV)
        );

        private static void SubHeadersSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry> gantChart))
                return;

            gantChart.CallingRedraw(oldValue, newValue, SubHeadersSourceProperty);
        }

        public ObservableCollection<string> SubHeadersSource
        {
            get => (ObservableCollection<string>)GetValue(SubHeadersSourceProperty);
            set => SetValue(SubHeadersSourceProperty, value);
        }


        /// <summary>
        /// Elements that need to be displayed in Gantt Chart in current section
        /// </summary>
        public static readonly BindableProperty EntriesSourceProperty = BindableProperty.Create
        (
            propertyName: nameof(EntriesSource),
            returnType: typeof(ObservableCollection<TGanttEntry>),
            declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
            defaultValue: default,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: (b, oV, nV) => EntriesSourceChanged(b, oV, nV)
        );

        public ObservableCollection<TGanttEntry> EntriesSource
        {
            get => (ObservableCollection<TGanttEntry>)GetValue(EntriesSourceProperty);
            set => SetValue(EntriesSourceProperty, value);
        }

        private static void EntriesSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry> gantChartSection))
                return;

            var entries = newValue as ObservableCollection<TGanttEntry>;

            CreateSectionEntries(gantChartSection, gantChartSection.Order, entries);

            gantChartSection.CallingRedraw(oldValue, newValue, EntriesSourceProperty);
        }



        /// <summary>
        /// Section Entries
        /// </summary>
        public static readonly BindableProperty SectionEntriesProperty = BindableProperty.Create
        (
            propertyName: nameof(SectionEntries),
            returnType: typeof(ObservableCollection<TGanttSectionEntry>),
            declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
            defaultValue: default,
            defaultBindingMode: BindingMode.OneWay
        );

        public ObservableCollection<TGanttSectionEntry> SectionEntries
        {
            get => (ObservableCollection<TGanttSectionEntry>)GetValue(SectionEntriesProperty);
            set => SetValue(SectionEntriesProperty, value);
        }

        #endregion


        //-------------------------- Additional Props -------------------------//

        #region Additionals



        /// <summary>
        /// ForceRedraw
        /// </summary>
        public static readonly BindableProperty ForceRedrawProperty = BindableProperty.Create
        (
            propertyName: nameof(ForceRedraw),
            returnType: typeof(bool),
            declaringType: typeof(GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry>),
            defaultValue: default,
            defaultBindingMode: default,
            propertyChanged: (b, oV, nV) => ForceRedrawChanged(b, oV, nV)
        );

        private static void ForceRedrawChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is GanttChartSectionViewBase<TGanttSectionEntry, TGanttEntry> gantChart))
                return;

            gantChart.CallingRedraw(oldValue, newValue, ForceRedrawProperty);
        }

        public bool ForceRedraw
        {
            get => (bool)GetValue(ForceRedrawProperty);
            set => SetValue(ForceRedrawProperty, value);
        }

        #endregion

        protected virtual void CallingRedraw(object oldValue, object newValue, BindableProperty prop) //Maybe usefull
                => InvalidateSurface(); //Call redraw

        /// <summary>
        /// Chart draw
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChartDraw(SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;


            canvas.Clear(BackgroundColor.ToSKColor());

            if (Width <= 0
                || WidthRequest <= 0
                || Height <= 0
                || HeightRequest <= 0) //cause division by 0 or empty canvas

                return;

            var scale = e.Info.Width / Width;
            canvas.Scale((float)scale); //To make sure that the drawing dimensions match the elements in Xamarin


            if (SectionEntries.IsEmpty()) //Nothing to draw
                return;

            DrawHeader(canvas);

            var headerHeight = SubHeadersSource.IsEmpty()
                ? HeaderHeight + SeparatorLineHeight
                : HeaderHeight + SubHeaderHeight + SeparatorLineHeight + SeparatorLineHeight;

            var position = 0;

            foreach (var entry in SectionEntries)
                DrawEntryIndicator(entry, position++, headerHeight, canvas);

        }

        /// <summary>
        /// Rendering chart header and the vertical grid
        /// </summary>
        /// Returns the top left position from which the chart can be drawn
        protected virtual void DrawHeader
        (
            SKCanvas canvas
        )
        {
            var position = (X: 0f, Y: 0f);
            var withSubs = !SubHeadersSource.IsEmpty();

            var headerHeight = withSubs
                ? HeaderHeight + SubHeaderHeight + SeparatorLineHeight
                : HeaderHeight;

            var tableHeight = SectionEntries.Sum(e => e.RawHeight + SeparatorLineHeight);


            if (withSubs)//Draw each subSection
            {
                var subSectionPosition = (position.X, Y: HeaderHeight + SeparatorLineHeight);
                foreach (var subSection in SubHeadersSource)
                {
                    subSectionPosition = DrawBreakLine
                    (
                        canvas,
                        subSectionPosition.X,
                        subSectionPosition.Y,
                        subSectionPosition.X,
                        tableHeight + subSectionPosition.Y + SubHeaderHeight + SeparatorLineHeight,
                        SeparatorLineHeight,
                        SeparatorLineColor.ToSKColor()
                    ); // Draw separator line between all subsection with height of all chart

                    subSectionPosition = DrawCell
                    (
                        subSection,
                        SubHeaderTextSize,
                        SubHeaderTextStyleWeight,
                        SubHeaderTextColor.ToSKColor(),
                        SubHeaderCellColor.ToSKColor(),
                        canvas,
                        subSectionPosition.X,
                        subSectionPosition.Y,
                        SubColumnWidth,
                        SubHeaderHeight
                    ); //Draw sub header

                }

                DrawBreakLine
                (
                    canvas,
                    position.X,
                    HeaderHeight,
                    ColumnWidth + SeparatorLineHeight,
                    HeaderHeight,
                    SeparatorLineHeight,
                    SeparatorLineColor.ToSKColor()
                ); // Draw horizontal separator between section header and subheaders
            }

            if (!withSubs) // Draw grid if not drawn
            {
                var vericalLineY = position.Y + HeaderHeight + SeparatorLineHeight;
                DrawBreakLine
                (
                    canvas,
                    position.X,
                    vericalLineY,
                    position.X,
                    tableHeight + vericalLineY,
                    SeparatorLineHeight,
                    SeparatorLineColor.ToSKColor()
                );
            }

            position = DrawBreakLine
            (
                canvas,
                position.X,
                position.Y,
                position.X,
                position.Y + HeaderHeight,
                SeparatorLineHeight,
                SeparatorLineColor.ToSKColor()
            ); // Draw vertical separator between section headers

            DrawCell
            (
                SectionName,
                HeaderTextSize,
                HeaderTextStyleWeight,
                HeaderTextColor.ToSKColor(),
                HeaderCellColor.ToSKColor(),
                canvas,
                position.X,
                position.Y,
                ColumnWidth,
                HeaderHeight
            ); // Draw header

            DrawBreakLine
            (
                canvas,
                0,
                headerHeight,
                ColumnWidth + SeparatorLineHeight,
                headerHeight,
                SeparatorLineHeight,
                SeparatorLineColor.ToSKColor()
            ); // Draw horizontal separator between section header and chart

        }

        /// <summary>
        /// Drawing indicator in section
        /// </summary>
        /// Returns the top left position of next right indicator in cell
        protected virtual (float X, float Y) DrawIndicator
        (
            SKColor indicatorColor,
            SKCanvas canvas,
            float startX,
            float startY,
            float endX,
            float indicatorHeight
        )
        {
            DrawIndicatorOnCanvas
            (
                indicatorColor,
                canvas,
                startX,
                startY,
                endX,
                indicatorHeight
            );

            return (endX, startY);
        }

        protected void DrawIndicatorOnCanvas
        (
            SKColor indicatorColor,
            SKCanvas canvas,
            float startX,
            float startY,
            float endX,
            float indicatorHeight
        )
        {
            var endY = startY + indicatorHeight;

            if (startX != endX) // No need to draw unnecessary indicators
            {
                using var cellPath = new SKPath
                {
                    FillType = SKPathFillType.Winding
                };

                cellPath.MoveTo(startX, startY);
                cellPath.LineTo(endX, startY);
                cellPath.LineTo(endX, endY);
                cellPath.LineTo(startX, endY);
                cellPath.Close();

                using var cellPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = indicatorColor
                };
                canvas.DrawPath(cellPath, cellPaint);
            }
        }

        /// <summary>
        /// Drawing a single cell with text positioned exactly in the middle
        /// </summary>
        /// Returns the coordinates of the upper-left corner of the next cell in the row
        protected virtual (float X, float Y) DrawCell
        (
            string text,
            float textSize,
            SKFontStyleWeight styleWeight,
            SKColor textColor,
            SKColor cellColor,
            SKCanvas canvas,
            float startX,
            float startY,
            float width,
            float height
        )
        {
            var endX = startX + width;
            var endY = startY + height;

            DrawCellOnCanvas
            (
                text,
                textSize,
                styleWeight,
                textColor,
                cellColor,
                canvas,
                startX,
                startY,
                width,
                height,
                endX,
                endY
            );

            return (endX, startY);
        }

        protected void DrawCellOnCanvas
        (
            string text,
            float textSize,
            SKFontStyleWeight styleWeight,
            SKColor textColor,
            SKColor cellColor,
            SKCanvas canvas,
            float startX,
            float startY,
            float width,
            float height,
            float endX,
            float endY
        )
        {
            using var cellPath = new SKPath
            {
                FillType = SKPathFillType.Winding
            };

            cellPath.MoveTo(startX, startY);
            cellPath.LineTo(endX, startY);
            cellPath.LineTo(endX, endY);
            cellPath.LineTo(startX, endY);
            cellPath.Close();

            using var cellPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = cellColor
            };
            canvas.DrawPath(cellPath, cellPaint);

            using var textPaint = new SKPaint
            {
                Color = textColor,
                TextSize = textSize,
                Typeface = SKTypeface.FromFamilyName("Arial", styleWeight, SKFontStyleWidth.Normal, default)
            };

            var textRect = new SKRect();
            var textWidth = textPaint.MeasureText(text, ref textRect); //Check that the text fits in the cell
            while (width < textRect.Width)
            {
                if (text.Length <= 0)
                    throw new NotSupportedException("The cell width is set too small");

                text = text.Substring(0, text.Length - 1);

                textWidth = textPaint.MeasureText(text, ref textRect); //Check that the text fits in the cell
            }

            canvas.DrawText(text, (width - textRect.Right) / 2f + startX, height - (height - textRect.Height) / 2f + startY, textPaint);
        }

        /// <summary>
        /// Drawing a vertical / horizontal line
        /// </summary>
        /// Returns the coordinates of the upper-left corner of the next cell (in a row / column)
        protected virtual (float X, float Y) DrawBreakLine
        (
            SKCanvas canvas,
            float startX,
            float startY,
            float endX,
            float endY,
            float width,
            SKColor? nullLineColor = null
        )
        {
            var isHorizontal = startY == endY;

            DrawBreakLineOnCanvas
            (
                isHorizontal,
                canvas,
                startX,
                startY,
                endX,
                endY,
                width,
                nullLineColor
            );

            return isHorizontal ? (startX, endY + width) : (endX + width, startY);
        }

        protected void DrawBreakLineOnCanvas
        (
            bool isHorizontal,
            SKCanvas canvas,
            float startX,
            float startY,
            float endX,
            float endY,
            float width,
            SKColor? nullLineColor = null
        )
        {
            var lineColor =
                nullLineColor
                ??
                SeparatorLineColor.ToSKColor();

            using var breakLinePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = lineColor,
                StrokeWidth = width
            };

            if (isHorizontal)
                canvas.DrawLine(startX, startY + width / 2f, endX, endY + width / 2f, breakLinePaint);
            else canvas.DrawLine(startX + width / 2f, startY, endX + width / 2f, endY, breakLinePaint);
        }

        /// <summary>
        /// Drawing a rectangular indicator for a single entry in the table
        /// </summary>
        /// Returns the coordinates of the upper-left corner of the next cell in the row
        protected virtual void DrawEntryIndicator
        (
            TGanttSectionEntry entry,
            int position,
            float headerHeight,
            SKCanvas canvas
        )
        {
            if (!entry.NeedToDraw) //  Not displayed on the chart(extra rendering)
                return;

            var entryStartYPositionRelativeToRaw = SectionEntries.Take(position).Sum(e => e.RawHeight + SeparatorLineHeight)
                + headerHeight + entry.IndicatorStartYPositionRelativeToRaw; // Top-left position of indicator

            var offsetFromStart = entry.Start * ColumnWidthWithSeparator;

            var indicatorPosition = (X: offsetFromStart, Y: entryStartYPositionRelativeToRaw);

            var implementationX = entry.Implementation * ColumnWidthWithSeparator;

            //var entryEndYPositionRelativeToRaw = entryStartYPositionRelativeToRaw + IndicatorHeight; // Нижняя линия показателя

            indicatorPosition = DrawIndicator
            (
                entry.ImplementationColor.ToSKColor(),
                canvas,
                indicatorPosition.X,
                indicatorPosition.Y,
                implementationX,
                entry.IndicatorHeight
            ); // implementation indicator

            if (entry.Implementation >= entry.Remaining)
                return; // No need to draw remaining indicator

            var endX = entry.Remaining * ColumnWidthWithSeparator;

            DrawIndicator
            (
                entry.RemainingColor.ToSKColor(),
                canvas,
                indicatorPosition.X,
                indicatorPosition.Y,
                endX,
                entry.IndicatorHeight
            ); // Remaining indicator
        }
    }
}