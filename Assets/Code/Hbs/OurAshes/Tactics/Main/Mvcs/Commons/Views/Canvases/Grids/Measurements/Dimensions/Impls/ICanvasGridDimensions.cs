using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Impls
{
    /// <summary>
    /// Canvas Grid Dimensions Impl
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