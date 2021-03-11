namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ICanvasConfigurationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICanvasGridCoordinates GetGridDimensions();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICanvasGridCoordinates GetGridPosition();
    }
}