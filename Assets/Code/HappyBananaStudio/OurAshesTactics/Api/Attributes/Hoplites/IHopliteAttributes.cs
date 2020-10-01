/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Bonus;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Hoplites
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IHopliteAttributes
        : IBonusAttributes
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
        HashSet<HopliteTraitEnum> GetHopliteTraitSet();
    }
}