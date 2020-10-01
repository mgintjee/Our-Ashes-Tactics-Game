/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Weapons;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Bonus
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IBonusAttributes
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDestructibleAttributes GetDestructibleAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMovableAttributes GetMoveableAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IWeaponAttributes GetWeaponAttributes();
    }
}