/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api.Weapons;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api
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