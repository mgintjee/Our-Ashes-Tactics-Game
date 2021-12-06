using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICanvasGridMeasurements
    {
        ICanvasGridCoordinates GetCoordinates();

        ICanvasGridDimensions GetDimensions();
    }
}