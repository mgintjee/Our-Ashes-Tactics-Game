using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Impl
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
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        public GridDimensions(float width, float height)
        {
            this.width = width;
            this.height = height;
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