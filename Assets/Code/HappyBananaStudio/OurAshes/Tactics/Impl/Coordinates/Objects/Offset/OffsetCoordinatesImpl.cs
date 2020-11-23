namespace HappyBananaStudio.OurAshes.Tactics.Impl.Coordinates.Objects.Offset
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Offset;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Coordinates;

    /// <summary>
    /// Todo
    /// </summary>
    public struct OffsetCoordinatesImpl
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
        public OffsetCoordinatesImpl(int colCoordinate, int rowCoordinate, OffsetCoordinateTypeEnum offsetCoordinateType)
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