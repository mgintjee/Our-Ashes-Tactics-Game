namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Sprites.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanelEntry
        : AbstractCanvasScript
    {
        // Todo
        protected IDictionary<IWidget, ICanvasConfigurationReport> widgetConfigurationReportDictionary =
            new Dictionary<IWidget, ICanvasConfigurationReport>();

        // Todo
        protected IBasicImage basicWidgetImage;

        // Todo
        protected IGridConvertor panelEntryGridConvertor;

        // Todo
        protected ICanvasGridCoordinates panelEntryGridDimensions;

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.GetGameObject().AddComponent<RectTransform>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void LoadBackgroundImage()
        {
            IWidget widget = new BasicImage.Builder()
                .SetParentTransform(this.GetTransform())
                .SetSpriteId(SpriteId.Square)
                .SetTransparency(0.5f)
                .SetColorId(ColorId.Gray)
                .Build();
            this.widgetConfigurationReportDictionary.Add(widget,
                new CanvasConfigurationReport.Builder()
                    .SetGridDimensions(this.panelEntryGridDimensions)
                .Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="panelGridConvertor"></param>
        /// <param name="panelEntryConfigurationReport"></param>
        protected void SetPanelEntryConfigurationReport(IGridConvertor panelGridConvertor,
            ICanvasConfigurationReport panelEntryConfigurationReport)
        {
            RectTransform rectTransform = this.GetComponent<RectTransform>();
            // Find the WorldDimensions for this panel
            Vector2 worldDimensions = panelGridConvertor.GetWorldDimensionsFrom(
                panelEntryConfigurationReport.GetGridDimensions());
            worldDimensions *= 0.9f;
            rectTransform.sizeDelta = worldDimensions;
            // Set the WorldPosition of this panel
            rectTransform.anchoredPosition =
                panelGridConvertor.GetWorldPositionFrom(
                    panelEntryConfigurationReport.GetGridPosition(),
                    panelEntryConfigurationReport.GetGridDimensions());
            // Collect the SizeDelta for this Panel
            Vector2 sizeDelta = rectTransform.sizeDelta;
            // Build the CanvasGridConvertor for this Panel
            this.panelEntryGridConvertor = new GridCoordinatesConvertor.Builder()
                .SetGridDimensions(this.panelEntryGridDimensions)
                .SetWorldWidth(sizeDelta.x)
                .SetWorldHeight(sizeDelta.y)
                .Build();
        }
    }
}