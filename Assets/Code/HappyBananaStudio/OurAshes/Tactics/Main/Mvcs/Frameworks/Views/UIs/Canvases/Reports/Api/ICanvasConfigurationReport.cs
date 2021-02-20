namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Canvas.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ICanvasConfigurationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICanvasGridCoordinates GetDimensionCanvasGridCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICanvasGridCoordinates GetPositionCanvasGridCoordinates();
    }
}