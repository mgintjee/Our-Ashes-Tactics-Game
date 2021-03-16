using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Api;
using UnityEngine;

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
        /// <param name="panelGridConvertor"></param>
        /// <param name="panelEntryConfigurationReport"></param>
        /// <param name="parentTransform"></param>
        void Initialize(IGridConvertor panelGridConvertor,
            IGridConfigurationReport panelEntryConfigurationReport,
            Transform parentTransform);

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateWidgets();
    }
}