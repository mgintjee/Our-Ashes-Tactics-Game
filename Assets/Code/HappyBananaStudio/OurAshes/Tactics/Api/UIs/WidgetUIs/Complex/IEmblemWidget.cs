namespace HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Complex
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IEmblemWidget
        : IWidgetUI
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="emblemSchemeReport">
        /// </param>
        /// <param name="colorSchemeReport">
        /// </param>
        void Initialize(IEmblemSchemeReport emblemSchemeReport, IColorSchemeReport colorSchemeReport);
    }
}