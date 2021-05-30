using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Positions.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Positions.Implementations
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
        public GridPosition(float col, float row)
        {
            this.col = col;
            this.row = row;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:({1},{2})", this.GetType().Name, this.col, this.row);
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
    }
}