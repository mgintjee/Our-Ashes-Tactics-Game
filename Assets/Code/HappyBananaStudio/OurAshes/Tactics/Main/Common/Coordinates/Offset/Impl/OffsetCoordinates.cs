using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Offset.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Offset.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Offset.Impl
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
        private readonly OffsetCoordinateType offsetCoordinateType;

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
        public OffsetCoordinates(int colCoordinate, int rowCoordinate, OffsetCoordinateType offsetCoordinateType)
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
        public OffsetCoordinateType GetOffsetCoordinateType()
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