/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Customization;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Hoplites
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IHopliteCustomizationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HopliteBodyModelIdEnum GetHopliteBodyModelId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HopliteHeadModelIdEnum GetHopliteHeadModelId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HopliteLegModelIdEnum GetHopliteLegModelId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IColorSchemeReport GetPaintSchemeReport();
    }
}