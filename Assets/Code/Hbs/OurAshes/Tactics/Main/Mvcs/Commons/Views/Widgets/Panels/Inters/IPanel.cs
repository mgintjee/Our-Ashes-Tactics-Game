using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Inters;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Panels.Inters
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