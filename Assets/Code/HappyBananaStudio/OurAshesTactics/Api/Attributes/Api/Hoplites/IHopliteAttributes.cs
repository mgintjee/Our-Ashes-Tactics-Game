/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api.Hoplites
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
        HashSet<HopliteTraitEnum> GetHopliteTraitSet();
    }
}