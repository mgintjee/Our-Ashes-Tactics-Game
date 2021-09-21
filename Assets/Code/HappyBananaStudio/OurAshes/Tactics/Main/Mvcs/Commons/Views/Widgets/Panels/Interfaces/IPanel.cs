using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Panels.Interfaces
{
    /// <summary>
    /// CanvasUI Interface
    /// </summary>
    public interface IPanel : ICanvasScript
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
        /// <param name="parentTransform">         </param>
        void Initialize(IGridConvertor canvasGridConvertor,
            ICanvasGridMeasurements panelConfigurationReport,
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