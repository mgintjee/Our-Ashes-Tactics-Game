using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Api;
using UnityEngine;

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
        /// Todo
        /// </summary>
        /// <param name="canvasGridConvertor"></param>
        /// <param name="panelConfigurationReport"></param>
        /// <param name="panelGridDimensions"></param>
        /// <param name="parentTransform"></param>
        void Initialize(IGridConvertor canvasGridConvertor,
            IGridConfigurationReport panelConfigurationReport,
            IGridDimensions panelGridDimensions,
            Transform parentTransform);
    }
}