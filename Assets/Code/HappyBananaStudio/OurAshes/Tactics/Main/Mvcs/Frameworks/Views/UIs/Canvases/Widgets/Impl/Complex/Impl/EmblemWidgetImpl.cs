/*namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Impl.Complex.Impl
{
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class EmblemWidgetImpl
        : AbstractComplexWidgetImpl, IEmblemWidget
    {
        // Todo
        private IBasicImageWidget backgroundImageWidget;

        // Todo
        private IColorSchemeReport colorSchemeReport;

        // Todo
        private IEmblemSchemeReport emblemSchemeReport;

        // Todo
        private IBasicImageWidget foregroundImageWidget;

        // Todo
        private IBasicImageWidget iconImageWidget;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="emblemSchemeReport">
        /// </param>
        /// <param name="colorSchemeReport">
        /// </param>
        void IEmblemWidget.Initialize(IEmblemSchemeReport emblemSchemeReport, IColorSchemeReport colorSchemeReport)
        {
            this.emblemSchemeReport = emblemSchemeReport;
            this.colorSchemeReport = colorSchemeReport;
            this.UpdateBackgroundImageWidget();
            this.UpdateForegroundImageWidget();
            this.UpdateIconImageWidget();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void LoadChildWidgets()
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.backgroundImageWidget = UIResourceLoader.WidgetUIs.Basics.LoadBasicImageWidget(this.GetTransform());
            this.foregroundImageWidget = UIResourceLoader.WidgetUIs.Basics.LoadBasicImageWidget(this.GetTransform());
            this.iconImageWidget = UIResourceLoader.WidgetUIs.Basics.LoadBasicImageWidget(this.GetTransform());

            this.foregroundImageWidget.GetRectTransform().sizeDelta *= 0.75f;
            this.iconImageWidget.GetRectTransform().sizeDelta *= 0.5f;

            // Add all of the children to the Set
            this.childWidgetSet.Add(this.backgroundImageWidget);
            this.childWidgetSet.Add(this.foregroundImageWidget);
            this.childWidgetSet.Add(this.iconImageWidget);
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void UpdateBackgroundImageWidget()
        {
            this.backgroundImageWidget.UpdateImage(SpriteResourceLoader.LoadSpriteResource(this.emblemSchemeReport.GetBackgroundId()));
            this.backgroundImageWidget.UpdateColor(EmblemColorUtil.GetColor(this.colorSchemeReport.GetPrimaryPaintColorId()));
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void UpdateForegroundImageWidget()
        {
            this.foregroundImageWidget.UpdateImage(SpriteResourceLoader.LoadSpriteResource(this.emblemSchemeReport.GetForegroundId()));
            this.foregroundImageWidget.UpdateColor(EmblemColorUtil.GetColor(this.colorSchemeReport.GetSecondaryPaintColorId()));
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void UpdateIconImageWidget()
        {
            this.iconImageWidget.UpdateImage(SpriteResourceLoader.LoadSpriteResource(this.emblemSchemeReport.GetIconId()));
            this.iconImageWidget.UpdateColor(EmblemColorUtil.GetColor(this.colorSchemeReport.GetTertiaryPaintColorId()));
        }
    }
}*/