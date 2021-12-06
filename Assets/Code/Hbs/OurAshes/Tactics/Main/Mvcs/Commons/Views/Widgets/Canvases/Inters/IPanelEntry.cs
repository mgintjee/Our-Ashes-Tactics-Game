using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Inters;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Inters
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