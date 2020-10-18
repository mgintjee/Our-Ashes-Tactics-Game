namespace HappyBananaStudio.OurAshes.Tactics.Impl.Widgets.Emblems
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Emblems.Widgets.Emblems;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets.Texts;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Emblems;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Unity.Scripts;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonEmblemWidgetImpl
        : UnityScriptImpl, ITalonEmblemWidget
    {
        // Todo
        private ISimpleTextWidget callSignTextWidget;

        // Todo
        private IEmblemWidget factionEmblemWidget;

        // Todo
        private IEmblemWidget phalanxEmblemWidget;

        // Todo
        [SerializeField] private Transform factionEmblemWidgetPosition;

        // Todo
        [SerializeField] private Transform phalanxEmblemWidgetPosition;

        // Todo
        [SerializeField] private Transform callSignWidgetPosition;


        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCustomizationReport"></param>
        /// <param name="callSign"></param>
        void ITalonEmblemWidget.Initialize(ITalonCustomizationReport talonCustomizationReport, CallSignEnum callSign)
        {
            this.Initialize(talonCustomizationReport);
            this.callSignTextWidget = WidgetResourceLoader.Texts.LoadSimpleTextWidget();
            this.callSignTextWidget.GetGameObject().transform.SetParent(this.callSignWidgetPosition);
            this.callSignTextWidget.UpdateText(CallSignsUtil.GetCharacter(callSign));
            this.callSignTextWidget.UpdateWidgetDimensions();
            this.callSignTextWidget.UpdateWidgetPosition();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void Initialize(ITalonCustomizationReport talonCustomizationReport)
        {
            this.factionEmblemWidget = WidgetResourceLoader.Emblems.LoadEmblemWidget
                (talonCustomizationReport.GetFactionEmblemSchemeReport(),
                talonCustomizationReport.GetFactionColorSchemeReport());
            this.phalanxEmblemWidget = WidgetResourceLoader.Emblems.LoadEmblemWidget(
                talonCustomizationReport.GetPhalanxEmblemSchemeReport(),
                talonCustomizationReport.GetPhalanxColorSchemeReport());

            this.factionEmblemWidget.GetGameObject().transform.SetParent(this.factionEmblemWidgetPosition);
            this.phalanxEmblemWidget.GetGameObject().transform.SetParent(this.phalanxEmblemWidgetPosition);

            this.factionEmblemWidget.UpdateWidgetDimensions();
            this.phalanxEmblemWidget.UpdateWidgetDimensions();

            this.factionEmblemWidget.UpdateWidgetPosition();
            this.phalanxEmblemWidget.UpdateWidgetPosition();

            this.factionEmblemWidget.UpdateTransparency(0.75f);
            this.phalanxEmblemWidget.UpdateTransparency(0.5f);
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IWidget.UpdateWidgetDimensions()
        {
            this.transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IWidget.UpdateWidgetPosition()
        {
            this.transform.localPosition = Vector3.zero;
        }
    }
}
