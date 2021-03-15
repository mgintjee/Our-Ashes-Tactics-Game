using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Traits.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Traits.Reports.Api
{
    /// <summary>
    /// Weapon Trait Report Api
    /// </summary>
    public interface IWeaponTraitReport
    {
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