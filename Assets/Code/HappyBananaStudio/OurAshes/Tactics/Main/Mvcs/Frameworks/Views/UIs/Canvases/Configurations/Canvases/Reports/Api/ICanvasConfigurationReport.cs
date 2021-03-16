using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Canvases.Reports.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICanvasConfigurationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridConfigurationReport GetActionMenuGridConfigurationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridConfigurationReport GetInformationalGridConfigurationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridConfigurationReport GetScoreBoardGridConfigurationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridConfigurationReport GetSettingMenuGridConfigurationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridConfigurationReport GetTurnScrollerGridConfigurationReport();
    }
}