namespace HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Complex
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonEmblemWidget
        : IWidgetUI
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCustomizationReport">
        /// </param>
        void Initialize(CallSign callSign, ITalonCustomizationReport talonCustomizationReport);
    }
}
