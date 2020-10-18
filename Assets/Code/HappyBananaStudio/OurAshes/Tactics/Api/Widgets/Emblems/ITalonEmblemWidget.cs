namespace HappyBananaStudio.OurAshes.Tactics.Api.Emblems.Widgets.Emblems
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonEmblemWidget
        : IWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCustomizationReport">
        /// </param>
        /// <param name="callSign">
        /// </param>
        void Initialize(ITalonCustomizationReport talonCustomizationReport, CallSignEnum callSign);
    }
}
