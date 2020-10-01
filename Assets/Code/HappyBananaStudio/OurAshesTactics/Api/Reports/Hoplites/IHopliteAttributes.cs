/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Hoplites
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IHopliteReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ControllerIdEnum GetControllerId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHopliteAttributes GetHopliteAttributes();
    }
}