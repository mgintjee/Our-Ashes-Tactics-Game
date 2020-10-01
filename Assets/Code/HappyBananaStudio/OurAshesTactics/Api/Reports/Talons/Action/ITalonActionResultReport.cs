/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonActionResultReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonActionOrderReport GetTalonActionOrder();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonAttributesReport GetTalonAttributesReport();
    }
}