using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Api;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class GridConvertorUtil
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="gridConvertor"></param>
        /// <param name="gridConfigurationReport"></param>
        public static void ApplyGridConfigurationReport(IPanel panel, IGridConvertor gridConvertor,
            IGridConfigurationReport gridConfigurationReport)
        {
            ApplyGridConfigurationReport((ICanvasScript)panel, gridConvertor, gridConfigurationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widget"></param>
        /// <param name="gridConvertor"></param>
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
        /// <param name="panelEntry"></param>
        /// <param name="gridConvertor"></param>
        /// <param name="gridConfigurationReport"></param>
        public static void ApplyGridConfigurationReport(IPanelEntry panelEntry, IGridConvertor gridConvertor,
            IGridConfigurationReport gridConfigurationReport)
        {
            ApplyGridConfigurationReport((ICanvasScript)panelEntry, gridConvertor, gridConfigurationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasScript"></param>
        /// <param name="gridConvertor"></param>
        /// <param name="gridConfigurationReport"></param>
        private static void ApplyGridConfigurationReport(ICanvasScript canvasScript,
            IGridConvertor gridConvertor, IGridConfigurationReport gridConfigurationReport)
        {
            logger.Debug("Applyling ? to ?", gridConfigurationReport, canvasScript.GetType().Name);
            RectTransform rectTransform = canvasScript.GetRectTransform();
            logger.Debug("Original SizeDelta=?, AnchoredPosition=?",
                rectTransform.sizeDelta, rectTransform.anchoredPosition);
            // Find the WorldDimensions for this canvasScript
            Vector2 worldDimensions = gridConvertor.GetWorldDimensionsFrom(
                gridConfigurationReport.GetGridDimensions());
            // Apply an offset
            // TODO: Store in a const file
            worldDimensions *= 0.95f;
            // Set the WorldDimensions for this canvasScript
            rectTransform.sizeDelta = worldDimensions;
            // Set the WorldPosition of this canvasScript
            rectTransform.anchoredPosition = gridConvertor.GetWorldPositionFrom(
                    gridConfigurationReport.GetGridPosition(),
                    gridConfigurationReport.GetGridDimensions());
            logger.Debug("Converted SizeDelta=?, AnchoredPosition=?",
                rectTransform.sizeDelta, rectTransform.anchoredPosition);
        }
    }
}