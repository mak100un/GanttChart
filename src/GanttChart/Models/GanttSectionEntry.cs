using System.ComponentModel.DataAnnotations;
using Xamarin.Forms;

namespace GanttChart.Models
{
    /// <summary>
    /// Entry, which indicator should be drawn on gant chart in current section
    /// <para>If <see cref="Start"/> will be == 0 and <see cref="Implementation"/> == 1, indicator will take place of all section</para>
    /// </summary>
    public class GanttSectionEntry
    {
        //-------------------------- Sizes Props -------------------------//

        #region Sizes

        /// <summary>
        /// Height of indicator
        /// </summary>
        public float IndicatorHeight { get; set; } = 16f;

        /// <summary>
        /// Indent from the top of raw to draw the indicator in the center
        /// </summary>
        public float IndicatorStartYPositionRelativeToRaw => (RawHeight - IndicatorHeight) / 2;



        /// <summary>
        /// Height of entry raw
        /// </summary>
        public float RawHeight { get; set; } = 98f;

        #endregion


        //-------------------------- Color Props -------------------------//

        #region Colors


        /// <summary>
        /// Сolor of implementation indicator
        /// </summary>
        public Color ImplementationColor { get; set; }



        /// <summary>
        /// Сolor of remaining works indicator 
        /// </summary>
        public Color RemainingColor { get; set; }


        #endregion


        /// <summary>
        /// Start of chart section indicator (0 - minimum)
        /// от 0 - 1
        /// </summary>
        [Range(0, 1)]
        public float Start { get; set; }

        /// <summary>
        /// End of remaining indicator (1 - maximum)
        /// от 0 - 1
        /// </summary>
        [Range(0, 1)]
        public float Remaining { get; set; }

        /// <summary>
        /// End of implementation indicator (1 - maximum)
        /// Value must be >= <see cref="Start"/>
        /// </summary>
        [Range(0, 1)]
        public float Implementation { get; set; }


        /// <summary>
        /// In order to prevent unnecessary draw
        /// </summary>
        public bool NeedToDraw => !(Start == Implementation && Implementation == Remaining);
    }
}
