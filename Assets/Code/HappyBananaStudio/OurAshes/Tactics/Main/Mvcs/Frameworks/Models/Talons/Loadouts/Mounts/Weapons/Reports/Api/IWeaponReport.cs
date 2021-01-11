using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Reports.Api
{
    /// <summary>
    /// Weapon Report Api
    /// </summary>
    public interface IWeaponReport
        : IMountReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponId GetWeaponId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponType GetWeaponType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponTraitAmmo GetWeaponTraitAmmo();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponTraitBarrel GetWeaponTraitBarrel();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponTraitMagazine GetWeaponTraitMagazine();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponTraitTargeting GetWeaponTraitTargeting();
    }
}