using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api
{
    /// <summary>
    /// CanvasUI Api
    /// </summary>
    public interface IPanel
        : ICanvasScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        void UpdatePanelEntries();

        /// <summary>
        ///
        /// </summary>
        /// <param name="canvasGridConvertor"></param>
        /// <param name="panelConfigurationReport"></param>
        void SetPanelConfigurationReport(IGridConvertor canvasGridConvertor,
            IGridConfigurationReport panelConfigurationReport);
    }
}