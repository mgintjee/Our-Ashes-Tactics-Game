/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Paints
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPaintSchemeReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        PaintColorIdEnum GetPrimaryPaintColorId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        PaintColorIdEnum GetSecondaryPaintColorId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        PaintColorIdEnum GetTertiaryPaintColorId();
    }
}