/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Customization
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IColorSchemeReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ColorIdEnum GetPrimaryPaintColorId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ColorIdEnum GetSecondaryPaintColorId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ColorIdEnum GetTertiaryPaintColorId();
    }
}