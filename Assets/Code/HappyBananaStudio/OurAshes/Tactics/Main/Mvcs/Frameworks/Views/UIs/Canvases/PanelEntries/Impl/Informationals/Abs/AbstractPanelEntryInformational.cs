namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Sprites.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Texts.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Texts.Impl;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanelEntryInformational
        : AbstractPanelEntry, IPanelEntryInformational
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="headerString"></param>
        protected void BuildHeader(string headerString)
        {
            IComplexText complexWidgetHeader = new ComplexText.Builder()
                .SetParentTransform(this.GetTransform())
                .SetImageColorId(ColorId.Gray)
                .SetImageSpriteId(SpriteId.RoundedSquare)
                .SetImageTransparency(0.0f)
                .SetTextColorId(ColorId.Black)
                .SetTextFontSize(15)
                .SetTextFontStyle(FontStyle.Bold)
                .SetTextString(headerString)
                .Build();
            // Todo: Store this in the abstract probably
            this.widgetConfigurationReportDictionary.Add(
                complexWidgetHeader, new CanvasConfigurationReport.Builder()
                        .SetGridDimensions(new GridCoordinates.Builder()
                            .SetCol(1).SetRow(4)
                            .Build())
                        .SetGridPosition(new GridCoordinates.Builder()
                            .SetCol(0).SetRow(0)
                            .Build())
                    .Build());
        }

        void IPanelEntry.UpdateWidgets()
        {
            throw new System.NotImplementedException();
        }
    }
}