using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Dimensions.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Dimensions.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct GridDimensions
        : IGridDimensions
    {
        // Todo
        private readonly float height;

        // Todo
        private readonly float width;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="width"> </param>
        /// <param name="height"></param>
        public GridDimensions(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:({1},{2})",
                this.GetType().Name, this.width, this.height);
        }

        /// <inheritdoc/>
        float IGridDimensions.GetHeight()
        {
            return this.height;
        }

        /// <inheritdoc/>
        float IGridDimensions.GetWidth()
        {
            return this.width;
        }
    }
}