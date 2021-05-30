using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Offset.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Offset.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Offset.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct OffsetCoordinates
        : IOffsetCoordinates
    {
        // Todo
        private readonly int _col;

        // Todo
        private readonly OffsetCoordinateType _offsetCoordinateType;

        // Todo
        private readonly int _row;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col">                 </param>
        /// <param name="row">                 </param>
        /// <param name="offsetCoordinateType"></param>
        public OffsetCoordinates(int col, int row, OffsetCoordinateType offsetCoordinateType)
        {
            _col = col;
            _row = row;
            _offsetCoordinateType = offsetCoordinateType;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:{1},({2},{3})",
                this.GetType().Name, _offsetCoordinateType,
                _col, _row);
        }

        /// <inheritdoc/>
        int IOffsetCoordinates.GetCol()
        {
            return _col;
        }

        /// <inheritdoc/>
        OffsetCoordinateType IOffsetCoordinates.GetOffsetCoordinateType()
        {
            return _offsetCoordinateType;
        }

        /// <inheritdoc/>
        int IOffsetCoordinates.GetRow()
        {
            return _row;
        }
    }
}