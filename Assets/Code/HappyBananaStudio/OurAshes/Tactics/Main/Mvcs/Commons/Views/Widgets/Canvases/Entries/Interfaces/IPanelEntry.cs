using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Canvases.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Entries.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPanelEntry : ICanvasScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="panelGridConvertor">           </param>
        /// <param name="panelEntryConfigurationReport"></param>
        /// <param name="parentTransform">              </param>
        void Initialize(IGridConvertor panelGridConvertor,
            ICanvasGridMeasurements panelEntryConfigurationReport,
            Transform parentTransform);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isActive"></param>
        void SetActive(bool isActive);

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateWidgets();
    }
}