using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPanelEntry
        : ICanvasScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        void UpdateWidgets();

        /// <summary>
        ///
        /// </summary>
        /// <param name="canvasGridConvertor"></param>
        /// <param name="panelEntryConfigurationReport"></param>
        void SetPanelEntryConfigurationReport(IGridConvertor canvasGridConvertor,
            IGridConfigurationReport panelEntryConfigurationReport);
    }
}