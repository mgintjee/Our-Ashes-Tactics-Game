using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Coordinates.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Dimensions.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Interfaces
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