using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Sprites.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Abs
{
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
        protected IBasicImage backgroundImage;

        // Todo
        protected IGridConvertor panelGridConvertor;

        // Todo
        protected IGridDimensions panelGridDimensions;

        /// <inheritdoc/>
        void IPanel.UpdatePanelEntries()
        {
            // Todo
        }

        /// <inheritdoc/>
        void IPanel.Initialize(IGridConvertor canvasGridConvertor,
            IGridConfigurationReport panelConfigurationReport,
            IGridDimensions panelGridDimensions,
            Transform parentTransform)
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.SetParentTransform(parentTransform);
            this.panelGridDimensions = panelGridDimensions;
            GridConvertorUtil.ApplyGridConfigurationReport(this,
                canvasGridConvertor, panelConfigurationReport);
            this.BuildPanelGridConvertor();
            this.LoadBackgroundImage();
            this.LoadDefaultPanelEntry();
        }

        /// <summary>
        ///
        /// Todo
        /// </summary>
        protected void LoadBackgroundImage()
        {
            // Todo: Maybe have a default BasicImage Builder for background
            this.backgroundImage = new BasicImage.Builder()
                .SetParentTransform(this.GetTransform())
                .SetSpriteId(SpriteId.Square)
                .SetTransparency(0.5f)
                .SetColorId(ColorId.Gray)
                .Build();
            // TOdo: Store in a const file
            this.backgroundImage.GetTransform().name = "BackgroundImage";
            GridConvertorUtil.ApplyGridConfigurationReport(this.backgroundImage,
                this.panelGridConvertor, new GridConfigurationReport.Builder()
                .SetGridDimensions(this.panelGridDimensions)
                .Build());
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

        /// <inheritdoc/>
        protected abstract void LoadDefaultPanelEntry();

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildPanelGridConvertor()
        {
            // Collect the SizeDelta for this Panel
            Vector2 sizeDelta = this.GetComponent<RectTransform>().sizeDelta;
            // Build the GridConvertor for this Panel
            this.panelGridConvertor = new GridConvertor.Builder()
                .SetGridDimensions(this.panelGridDimensions)
                .SetWorldWidth(sizeDelta.x)
                .SetWorldHeight(sizeDelta.y)
                .Build();
        }
    }
}