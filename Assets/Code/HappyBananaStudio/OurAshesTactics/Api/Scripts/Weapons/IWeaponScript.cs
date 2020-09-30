/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Weapons
{
    /// <summary>
    /// Weapon Script Api
    /// </summary>
    public interface IWeaponScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        WeaponIdEnum GetWeaponId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IWeaponObject GetWeaponObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId">
        /// </param>
        void Initialize(WeaponIdEnum weaponId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();
    }
}