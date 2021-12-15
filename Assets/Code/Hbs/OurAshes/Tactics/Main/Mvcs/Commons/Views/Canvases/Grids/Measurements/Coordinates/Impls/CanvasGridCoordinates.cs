using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Impls
{
    /// <summary>
    /// Canvas Grid Coordinates Impl
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

        double ICanvasGridCoordinates.GetX()
        {
            return this.x;
        }

        double ICanvasGridCoordinates.GetY()
        {
            return this.y;
        }
    }
}