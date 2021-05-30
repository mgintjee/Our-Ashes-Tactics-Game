using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Canvases.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Convertors.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Entries.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Basics.Images;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Interfaces.Basics.Images;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Implementations.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanel
        : AbstractCanvasScript, IPanel
    {
        // Todo
        protected IBasicImage backgroundImage;

        // Todo
        protected IList<IPanelEntry> panelEntryList = new List<IPanelEntry>();

        // Todo
        protected IGridConvertor panelGridConvertor;

        // Todo
        protected IGridDimensions panelGridDimensions;

        /// <inheritdoc/>
        void IPanel.ClearPanelEntries()
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
            this.SetParent(parentTransform);
            this.panelGridDimensions = panelGridDimensions;
            GridConvertorUtil.ApplyGridConfigurationReport(this,
                canvasGridConvertor, panelConfigurationReport);
            this.BuildPanelGridConvertor();
            this.LoadBackgroundImage();
            this.LoadDefaultPanelEntry();
        }

        /// <inheritdoc/>
        void IPanel.LoadDefaultPanelEntry()
        {
            // Todo
        }

        /// <inheritdoc/>
        void IPanel.SetActive(bool isActive)
        {
            this.GetGameObject().SetActive(isActive);
        }

        /// <inheritdoc/>
        void IPanel.UpdatePanelEntries()
        {
            // Todo
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void LoadBackgroundImage()
        {
            // Todo: Maybe have a default BasicImage Builder for background
            this.backgroundImage = new BasicImage.Builder()
                .SetParentTransform(this.GetTransform())
                .SetSpriteId(SpriteID.Square)
                .SetTransparency(0.5f)
                .SetColorId(ColorID.Gray)
                .Build();
            // TOdo: Store in a const file
            this.backgroundImage.GetTransform().name = "BackgroundImage";
            GridConvertorUtil.ApplyGridConfigurationReport(this.backgroundImage,
                this.panelGridConvertor, new GridConfigurationReport.Builder()
                .SetGridDimensions(this.panelGridDimensions)
                .Build());
        }

        /// <inheritdoc/>
        protected abstract void LoadDefaultPanelEntry();

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
        /// <param name="panelEntry"></param>
        protected void RemovePanelEntry(IPanelEntry panelEntry)
        {
            this.panelEntryList.Remove(panelEntry);
            panelEntry.Destroy();
        }

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