/*namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Impl.Complex.Impl
{
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonSingleEmblemWidgetImpl
        : AbstractComplexWidgetImpl, ITalonEmblemWidget
    {
        // Todo
        private IBasicTextWidget callSignTextWidget;

        // Todo
        private IEmblemWidget emblemWidget;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        /// <param name="talonCustomizationReport">
        /// </param>
        public virtual void Initialize(TalonCallSign callSign, ITalonCustomizationReport talonCustomizationReport)
        {
            this.emblemWidget.Initialize(talonCustomizationReport.GetFactionEmblemSchemeReport(),
                talonCustomizationReport.GetFactionColorSchemeReport());
            this.callSignTextWidget.UpdateText(CallSignsUtil.GetCharacter(callSign));
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void LoadChildWidgets()
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.LoadEmblemWidgets();
            this.callSignTextWidget = UIResourceLoader.WidgetUIs.Basics.LoadBasicTextWidget(this.GetTransform());
            this.callSignTextWidget.UpdateFontStyle(FontStyle.Bold);
            this.callSignTextWidget.UpdateFontSize(25);
            this.childWidgetSet.Add(this.callSignTextWidget);
            Debug.Log("Children:" + string.Join(", ", this.childWidgetSet));
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected virtual void LoadEmblemWidgets()
        {
            this.emblemWidget = UIResourceLoader.WidgetUIs.Complex.LoadEmblemWidget(this.GetTransform());
            this.childWidgetSet.Add(this.emblemWidget);
        }
    }
}*/