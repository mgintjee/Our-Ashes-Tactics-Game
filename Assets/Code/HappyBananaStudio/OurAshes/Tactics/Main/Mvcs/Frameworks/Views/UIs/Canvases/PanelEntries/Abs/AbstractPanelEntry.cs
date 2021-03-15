using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Sprites.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Api;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Abs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanelEntry
        : AbstractCanvasScript, IPanelEntry
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        protected IDictionary<IWidget, IGridConfigurationReport> widgetConfigurationReportDictionary =
            new Dictionary<IWidget, IGridConfigurationReport>();

        // Todo
        protected IBasicImage basicWidgetImage;

        // Todo
        protected IGridConvertor panelEntryGridConvertor;

        // Todo
        [SerializeField] protected IGridDimensions panelEntryGridDimensions;

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.GetGameObject().AddComponent<RectTransform>();
        }

        void IPanelEntry.SetPanelEntryConfigurationReport(IGridConvertor canvasGridConvertor,
            IGridConfigurationReport panelEntryConfigurationReport)
        {
            RectTransform rectTransform = this.GetComponent<RectTransform>();
            // Find the WorldDimensions for this panel
            Vector2 worldDimensions = canvasGridConvertor.GetWorldDimensionsFrom(
                panelEntryConfigurationReport.GetGridDimensions());
            worldDimensions *= 0.9f;
            rectTransform.sizeDelta = worldDimensions;
            // Set the WorldPosition of this panel
            rectTransform.anchoredPosition = canvasGridConvertor.GetWorldPositionFrom(
                    panelEntryConfigurationReport.GetGridPosition(),
                    panelEntryConfigurationReport.GetGridDimensions());
            // Collect the SizeDelta for this Panel
            Vector2 sizeDelta = rectTransform.sizeDelta;
            // Build the CanvasGridConvertor for this Panel
            this.panelEntryGridConvertor = new GridConvertor.Builder()
                .SetGridDimensions(this.panelEntryGridDimensions)
                .SetWorldWidth(sizeDelta.x)
                .SetWorldHeight(sizeDelta.y)
                .Build();
        }

        void IPanelEntry.UpdateWidgets()
        {
            foreach (IWidget widget in this.widgetConfigurationReportDictionary.Keys)
            {
                if (widget is IComplexWidget complexWidget)
                {
                    complexWidget.UpdateWidgets();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widget"></param>
        /// <param name="widgetConfigurationReport"></param>
        protected void AddWidget(IWidget widget,
            IGridConfigurationReport widgetConfigurationReport)
        {
            logger.Debug("Adding Widget=?", widget.GetGameObject().name);
            this.widgetConfigurationReportDictionary.Add(widget, widgetConfigurationReport);
            widget.SetWidgetDimensions(this.panelEntryGridConvertor.GetWorldDimensionsFrom(
                widgetConfigurationReport.GetGridDimensions()));
            logger.Debug("Widget Dimensions=?",
                this.panelEntryGridConvertor.GetWorldDimensionsFrom(
                widgetConfigurationReport.GetGridDimensions()));
            widget.SetWidgetPosition(this.panelEntryGridConvertor.GetWorldPositionFrom(
                widgetConfigurationReport));
            logger.Debug("Widget Position=?",
                this.panelEntryGridConvertor.GetWorldPositionFrom(
                widgetConfigurationReport));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widget"></param>
        protected void RemoveWidget(IWidget widget)
        {
            this.widgetConfigurationReportDictionary.Remove(widget);
            widget.Destroy();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void LoadBackgroundImage()
        {
            IWidget backgroundImage = new BasicImage.Builder()
                .SetParentTransform(this.GetTransform())
                .SetSpriteId(SpriteId.Square)
                .SetTransparency(0.5f)
                .SetColorId(ColorId.Gray)
                .Build();
            // TOdo: Store in a const file
            backgroundImage.GetTransform().name = "BackgroundImage";
            this.AddWidget(backgroundImage,
                new GridConfigurationReport.Builder()
                    .SetGridDimensions(this.panelEntryGridDimensions)
                .Build());
        }
    }
}