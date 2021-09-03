using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Coordinates.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Coordinates.Implementations
{
    /// <summary>
    /// Canvas Grid Coordinates Implementation
    /// </summary>
    public struct CanvasGridCoordinates : ICanvasGridCoordinates
    {
        private readonly double x;
        private readonly double y;
        public CanvasGridCoordinates(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        double ICanvasGridCoordinates.getX()
        {
            return this.x;
        }

        double ICanvasGridCoordinates.getY()
        {
            return this.y;
        }
    }
}