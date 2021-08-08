using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Reports.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Entries.Interfaces
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
        /// <param name="panelGridConvertor">           </param>
        /// <param name="panelEntryConfigurationReport"></param>
        /// <param name="parentTransform">              </param>
        void Initialize(IGridConvertor panelGridConvertor,
            IGridConfigurationReport panelEntryConfigurationReport,
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