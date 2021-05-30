using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Reports.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Interfaces
{
    /// <summary>
    /// CanvasUI Interface
    /// </summary>
    public interface IPanel
        : ICanvasScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        void ClearPanelEntries();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridConvertor">     </param>
        /// <param name="panelConfigurationReport"></param>
        /// <param name="panelGridDimensions">     </param>
        /// <param name="parentTransform">         </param>
        void Initialize(IGridConvertor canvasGridConvertor,
            IGridConfigurationReport panelConfigurationReport,
            IGridDimensions panelGridDimensions,
            Transform parentTransform);

        /// <summary>
        /// Todo
        /// </summary>
        void LoadDefaultPanelEntry();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isActive"></param>
        void SetActive(bool isActive);

        /// <summary>
        /// Todo
        /// </summary>
        void UpdatePanelEntries();
    }
}