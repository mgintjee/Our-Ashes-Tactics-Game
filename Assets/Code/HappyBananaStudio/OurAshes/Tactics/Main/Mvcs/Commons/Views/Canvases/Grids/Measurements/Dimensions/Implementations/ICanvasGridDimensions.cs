using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Implementations
{
    /// <summary>
    /// Canvas Grid Dimensions Implementation
    /// </summary>
    public struct CanvasGridDimensions : ICanvasGridDimensions
    {
        private readonly double height;
        private readonly double width;

        public CanvasGridDimensions(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        double ICanvasGridDimensions.GetHeight()
        {
            return this.height;
        }

        double ICanvasGridDimensions.GetWidth()
        {
            return this.width;
        }
    }
}