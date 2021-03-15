namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IViewConfigurationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridConfigurationReport GetCanvasActionMenuConfigurationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridConfigurationReport GetCanvasInformationalConfigurationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridConfigurationReport GetCanvasScoreBoardConfigurationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridConfigurationReport GetCanvasSettingMenuConfigurationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridConfigurationReport GetCanvasTurnScrollerConfigurationReport();
    }
}