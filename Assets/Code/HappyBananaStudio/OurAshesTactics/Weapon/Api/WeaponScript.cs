/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api
{
    /// <summary>
    /// Weapon Script Api
    /// </summary>
    public abstract class WeaponScript
    : AbstractUnityScript
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract WeaponIdEnum GetWeaponId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract IWeaponObject GetWeaponObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        public abstract void Initialize(WeaponIdEnum weaponId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract bool IsInitialized();

        #endregion Public Methods
    }
}