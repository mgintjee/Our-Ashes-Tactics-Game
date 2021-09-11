using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Canvases.Scripts.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Entries.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Panels.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Panels.Implementations.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanel : AbstractCanvasScript, IPanel
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
            ICanvasGridMeasurements panelConfigurationReport,
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
                .SetSpriteID(SpriteID.Square)
                .SetTransparency(0.5f)
                .SetColorID(ColorID.Gray)
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