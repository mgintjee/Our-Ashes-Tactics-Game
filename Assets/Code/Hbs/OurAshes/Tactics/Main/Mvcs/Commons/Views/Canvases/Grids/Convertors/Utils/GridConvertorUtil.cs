using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Entries.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Panels.Interfaces;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Utils
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
        /// <param name="CanvasGridMeasurements"></param>
        public static void ApplyCanvasGridMeasurements(IPanel panel, IGridConvertor gridConvertor,
            ICanvasGridMeasurements CanvasGridMeasurements)
        {
            ApplyCanvasGridMeasurements((ICanvasScript)panel, gridConvertor, CanvasGridMeasurements);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widget">                   </param>
        /// <param name="gridConvertor">            </param>
        /// <param name="widgetConfigurationReport"></param>
        public static void ApplyCanvasGridMeasurements(IWidget widget, IGridConvertor gridConvertor,
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
        /// <param name="CanvasGridMeasurements"></param>
        public static void ApplyCanvasGridMeasurements(IPanelEntry panelEntry, IGridConvertor gridConvertor,
            ICanvasGridMeasurements CanvasGridMeasurements)
        {
            ApplyCanvasGridMeasurements((ICanvasScript)panelEntry, gridConvertor, CanvasGridMeasurements);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasScript">           </param>
        /// <param name="gridConvertor">          </param>
        /// <param name="CanvasGridMeasurements"></param>
        private static void ApplyCanvasGridMeasurements(ICanvasScript canvasScript,
            IGridConvertor gridConvertor, ICanvasGridMeasurements CanvasGridMeasurements)
        {
            // Find the WorldDimensions for this canvasScript
            Vector2 worldDimensions = gridConvertor.GetWorldDimensionsFrom(
                CanvasGridMeasurements.GetDimensions());
            RectTransform rectTransform = canvasScript.GetRectTransform();
            float maxDimension = Mathf.Max(gridConvertor.GetWorldWidth(), gridConvertor.GetWorldHeight());
            // Apply some offsets
            worldDimensions.x -= maxDimension * 0.005f;
            worldDimensions.y -= maxDimension * 0.005f;
            // Set the WorldDimensions for this canvasScript
            rectTransform.sizeDelta = worldDimensions;
            // Set the WorldPosition of this canvasScript
            rectTransform.anchoredPosition = gridConvertor.GetWorldPositionFrom(
                    CanvasGridMeasurements.GetCoordinates(),
                    CanvasGridMeasurements.GetDimensions());
        }
    }
}