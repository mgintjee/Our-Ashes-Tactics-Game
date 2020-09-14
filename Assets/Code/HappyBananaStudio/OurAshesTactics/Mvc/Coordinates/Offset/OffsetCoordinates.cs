/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Util;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Offset
{
    /// <summary>
    /// Todo
    /// </summary>
    public class OffsetCoordinates
    {
        #region Private Fields

        // Todo
        private readonly int colCoordinate;

        // Todo
        private readonly OffsetCoordinateTypeEnum offsetCoordinateType;

        // Todo
        private readonly int rowCoordinate;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colCoordinate">       </param>
        /// <param name="rowCoordinate">       </param>
        /// <param name="offsetCoordinateType"></param>
        public OffsetCoordinates(int colCoordinate, int rowCoordinate, OffsetCoordinateTypeEnum offsetCoordinateType)
        {
            this.colCoordinate = colCoordinate;
            this.rowCoordinate = rowCoordinate;
            this.offsetCoordinateType = offsetCoordinateType;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetCol()
        {
            return this.colCoordinate;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public OffsetCoordinateTypeEnum GetOffsetCoordinateType()
        {
            return this.offsetCoordinateType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetRow()
        {
            return this.rowCoordinate;
        }

        #endregion Public Methods
    }
}