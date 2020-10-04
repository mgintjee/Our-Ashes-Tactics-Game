/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Customization
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonCustomizationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IColorSchemeReport GetFactionColorSchemeReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IEmblemSchemeReport GetFactionEmblemSchemeReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IColorSchemeReport GetPhalanxColorSchemeReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IEmblemSchemeReport GetPhalanxEmblemSchemeReport();
    }
}