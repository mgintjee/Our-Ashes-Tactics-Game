/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Hoplites
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IHopliteConstructionReport
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