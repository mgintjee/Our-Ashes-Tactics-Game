namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Mounts.Weapons.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Mounts.Common.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Mounts.Weapons.Enums;

    /// <summary>
    /// Mount Weapon Object Api
    /// </summary>
    public interface IMountWeaponObject
        : ILoadoutObject
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
        MountSize GetMountSize();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponIdType GetWeaponType();

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