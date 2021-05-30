using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Entries.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class GridConvertorUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="panel">                  </param>
        /// <param name="gridConvertor">          </param>
        /// <param name="gridConfigurationReport"></param>
        public static void ApplyGridConfigurationReport(IPanel panel, IGridConvertor gridConvertor,
            IGridConfigurationReport gridConfigurationReport)
        {
            ApplyGridConfigurationReport((ICanvasScript)panel, gridConvertor, gridConfigurationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widget">                   </param>
        /// <param name="gridConvertor">            </param>
        /// <param name="widgetConfigurationReport"></param>
        public static void ApplyGridConfigurationReport(IWidget widget, IGridConvertor gridConvertor,
            IGridConfigurationReport widgetConfigurationReport)
        {
            widget.SetWidgetDimensions(gridConvertor.GetWorldDimensionsFrom(
                widgetConfigurationReport.GetGridDimensions()));
            widget.SetWidgetPosition(gridConvertor.GetWorldPositionFrom(
                widgetConfigurationReport));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="panelEntry">             </param>
        /// <param name="gridConvertor">          </param>
        /// <param name="gridConfigurationReport"></param>
        public static void ApplyGridConfigurationReport(IPanelEntry panelEntry, IGridConvertor gridConvertor,
            IGridConfigurationReport gridConfigurationReport)
        {
            ApplyGridConfigurationReport((ICanvasScript)panelEntry, gridConvertor, gridConfigurationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasScript">           </param>
        /// <param name="gridConvertor">          </param>
        /// <param name="gridConfigurationReport"></param>
        private static void ApplyGridConfigurationReport(ICanvasScript canvasScript,
            IGridConvertor gridConvertor, IGridConfigurationReport gridConfigurationReport)
        {
            // Find the WorldDimensions for this canvasScript
            Vector2 worldDimensions = gridConvertor.GetWorldDimensionsFrom(
                gridConfigurationReport.GetGridDimensions());
            RectTransform rectTransform = canvasScript.GetRectTransform();
            float maxDimension = Mathf.Max(gridConvertor.GetWorldWidth(), gridConvertor.GetWorldHeight());
            // Apply some offsets
            worldDimensions.x -= maxDimension * 0.005f;
            worldDimensions.y -= maxDimension * 0.005f;
            // Set the WorldDimensions for this canvasScript
            rectTransform.sizeDelta = worldDimensions;
            // Set the WorldPosition of this canvasScript
            rectTransform.anchoredPosition = gridConvertor.GetWorldPositionFrom(
                    gridConfigurationReport.GetGridPosition(),
                    gridConfigurationReport.GetGridDimensions());
        }
    }
}