
namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Color;

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
