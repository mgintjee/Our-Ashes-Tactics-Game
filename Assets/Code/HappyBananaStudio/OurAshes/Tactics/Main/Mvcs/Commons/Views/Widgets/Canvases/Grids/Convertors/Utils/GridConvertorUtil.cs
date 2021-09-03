using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Coordinates.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Coordinates.Grids.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Entries.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Panels.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Widgets.Utils
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
            ICanvasGridMeasurements gridConfigurationReport)
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
            ICanvasGridMeasurements widgetConfigurationReport)
        {
            widget.SetWidgetDimensions(gridConvertor.GetWorldDimensionsFrom(
                widgetConfigurationReport.GetDimensions()));
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
            ICanvasGridMeasurements gridConfigurationReport)
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
            IGridConvertor gridConvertor, ICanvasGridMeasurements gridConfigurationReport)
        {
            // Find the WorldDimensions for this canvasScript
            Vector2 worldDimensions = gridConvertor.GetWorldDimensionsFrom(
                gridConfigurationReport.GetDimensions());
            RectTransform rectTransform = canvasScript.GetRectTransform();
            float maxDimension = Mathf.Max(gridConvertor.GetWorldWidth(), gridConvertor.GetWorldHeight());
            // Apply some offsets
            worldDimensions.x -= maxDimension * 0.005f;
            worldDimensions.y -= maxDimension * 0.005f;
            // Set the WorldDimensions for this canvasScript
            rectTransform.sizeDelta = worldDimensions;
            // Set the WorldPosition of this canvasScript
            rectTransform.anchoredPosition = gridConvertor.GetWorldPositionFrom(
                    gridConfigurationReport.GetCoordinates(),
                    gridConfigurationReport.GetDimensions());
        }
    }
}