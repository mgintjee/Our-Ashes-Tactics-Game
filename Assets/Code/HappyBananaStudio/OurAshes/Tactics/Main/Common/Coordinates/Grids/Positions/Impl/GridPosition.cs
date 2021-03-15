using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Positions.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Positions.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct GridPosition
        : IGridPosition
    {
        // Todo
        private readonly float col;

        // Todo
        private readonly float row;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        public GridPosition(int col, int row)
        {
            this.col = col;
            this.row = row;
        }

        /// <inheritdoc/>
        float IGridPosition.GetCol()
        {
            return this.col;
        }

        /// <inheritdoc/>
        float IGridPosition.GetRow()
        {
            return this.row;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}:({1},{2})", this.GetType().Name, this.col, this.row);
        }
    }
}