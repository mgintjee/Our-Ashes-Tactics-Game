using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces
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