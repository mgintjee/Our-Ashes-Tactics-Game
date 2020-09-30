/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Coordinates.Offset
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct OffsetCoordinates
        : IOffsetCoordinates
    {
        // Todo
        private readonly int colCoordinate;

        // Todo
        private readonly OffsetCoordinateTypeEnum offsetCoordinateType;

        // Todo
        private readonly int rowCoordinate;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colCoordinate">
        /// </param>
        /// <param name="rowCoordinate">
        /// </param>
        /// <param name="offsetCoordinateType">
        /// </param>
        public OffsetCoordinates(int colCoordinate, int rowCoordinate, OffsetCoordinateTypeEnum offsetCoordinateType)
        {
            this.colCoordinate = colCoordinate;
            this.rowCoordinate = rowCoordinate;
            this.offsetCoordinateType = offsetCoordinateType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetCol()
        {
            return this.colCoordinate;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public OffsetCoordinateTypeEnum GetOffsetCoordinateType()
        {
            return this.offsetCoordinateType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetRow()
        {
            return this.rowCoordinate;
        }
    }
}