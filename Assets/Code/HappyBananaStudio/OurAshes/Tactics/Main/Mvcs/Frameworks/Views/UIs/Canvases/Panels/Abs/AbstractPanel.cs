namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Sprites.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanel
        : AbstractCanvasScript, IPanel
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        protected IList<IPanelEntry> panelEntryList = new List<IPanelEntry>();

        // Todo
        protected IBasicImage basicWidgetImage;

        // Todo
        protected IGridConvertor panelGridConvertor;

        // Todo
        protected ICanvasGridCoordinates panelGridDimensions;

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
            this.basicWidgetImage = new BasicImage.Builder()
                .SetParentTransform(this.GetTransform())
                .SetSpriteId(SpriteId.Square)
                .SetTransparency(0.5f)
                .SetColorId(ColorId.Gray)
                .Build();
        }

        /// <inheritdoc/>
        void IPanel.UpdatePanelEntries()
        {
            // Todo
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="panelEntry"></param>
        /// <param name="panelEntryConfigurationReport"></param>
        protected void AddPanelEntry(IPanelEntry panelEntry,
            ICanvasConfigurationReport panelEntryConfigurationReport)
        {
            this.panelEntryList.Add(panelEntry);
            // TODO: Update the panelEntry based off of the config report and convertor
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="panelEntry"></param>
        protected void RemovePanelEntry(IPanelEntry panelEntry)
        {
            this.panelEntryList.Remove(panelEntry);
            panelEntry.Destroy();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void RemovePanelEntries()
        {
            foreach (IPanelEntry panelEntry in this.panelEntryList)
            {
                panelEntry.Destroy();
            }
            this.panelEntryList.Clear();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridConvertor"></param>
        /// <param name="panelConfigurationReport"></param>
        protected void SetPanelConfigurationReport(IGridConvertor canvasGridConvertor,
            ICanvasConfigurationReport panelConfigurationReport)
        {
            RectTransform rectTransform = this.GetComponent<RectTransform>();
            // Find the WorldDimensions for this panel
            Vector2 worldDimensions = canvasGridConvertor.GetWorldDimensionsFrom(
                panelConfigurationReport.GetGridDimensions());
            worldDimensions *= 0.9f;
            this.basicWidgetImage.SetWidgetDimensions(worldDimensions);
            rectTransform.sizeDelta = worldDimensions;
            // Set the WorldPosition of this panel
            rectTransform.anchoredPosition = canvasGridConvertor.GetWorldPositionFrom(
                    panelConfigurationReport.GetGridPosition(),
                    panelConfigurationReport.GetGridDimensions());
            // Collect the SizeDelta for this Panel
            Vector2 sizeDelta = rectTransform.sizeDelta;
            // Build the CanvasGridConvertor for this Panel
            this.panelGridConvertor = new GridCoordinatesConvertor.Builder()
                .SetGridDimensions(this.panelGridDimensions)
                .SetWorldWidth(sizeDelta.x)
                .SetWorldHeight(sizeDelta.y)
                .Build();
        }
    }
}