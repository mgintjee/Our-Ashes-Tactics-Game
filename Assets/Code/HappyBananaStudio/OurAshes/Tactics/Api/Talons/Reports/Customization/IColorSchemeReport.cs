/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Schemes.Enums;

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
