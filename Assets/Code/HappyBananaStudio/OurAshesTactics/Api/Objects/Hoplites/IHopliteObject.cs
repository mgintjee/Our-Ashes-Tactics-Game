/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Hoplites;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Hoplites
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IHopliteObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHopliteCustomizationReport GetHopliteCustomizationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHopliteInformationReport GetHopliteInformationReport();
    }
}