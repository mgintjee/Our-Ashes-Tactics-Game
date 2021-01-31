/*namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Impl.Complex.Impl
{
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonDoubleEmblemWidgetImpl
        : TalonSingleEmblemWidgetImpl
    {
        // Todo
        private IEmblemWidget emblemWidget;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        /// <param name="talonCustomizationReport">
        /// </param>
        public override void Initialize(TalonCallSign callSign, ITalonCustomizationReport talonCustomizationReport)
        {
            base.Initialize(callSign, talonCustomizationReport);
            this.emblemWidget.Initialize(talonCustomizationReport.GetPhalanxEmblemSchemeReport(),
                talonCustomizationReport.GetPhalanxColorSchemeReport());
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void LoadEmblemWidgets()
        {
            base.LoadEmblemWidgets();
            this.emblemWidget = UIResourceLoader.WidgetUIs.Complex.LoadEmblemWidget(this.GetTransform());
            Vector2 parentSizeDelta = this.GetComponent<RectTransform>().sizeDelta;
            this.emblemWidget.UpdateWidgetDimensions(parentSizeDelta * 0.75f);
            this.emblemWidget.UpdateWidgetPosition(new Vector2(parentSizeDelta.x * 0.75f / 2f, -parentSizeDelta.y * 0.75f / 2f));
            this.childWidgetSet.Add(this.emblemWidget);
        }
    }
}*/