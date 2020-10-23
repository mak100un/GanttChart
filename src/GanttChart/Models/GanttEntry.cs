using Xamarin.Forms;

namespace GanttChart.Models
{
    public class GanttEntry
    {
        //-------------------------- Sizes Props -------------------------//

        #region Sizes

        /// <summary>
        /// Height of indicator
        /// </summary>
        public float IndicatorHeight { get; set; } = 16f;

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


        /// <summary>
        /// Name of Entry
        /// </summary>
        public string Name { get; set; }


        #endregion


        /// <summary>
        ///  Order number of section where indicator should start and offset from start of section (0 - minimum)
        /// </summary>
        public (int Section, float Percent) Start { get; set; }

        /// <summary>
        /// Order number of section where indicator should end its remaining works and offset from start of section (1 - maximum)
        /// </summary>
        public (int Section, float Percent) Remaining { get; set; }

        /// <summary>
        /// Order number of section where indicator should end its implementation works and offset from start of section (1 - maximum)
        /// <para>Value of (<see cref="Implementation.Section"/> + <see cref="Implementation.Implementation"/>) must be >= (<see cref="Start.Section"/> + <see cref="Start.Start"/>)</para>
        /// </summary>
        public (int Section, float Percent) Implementation { get; set; }
    }
}