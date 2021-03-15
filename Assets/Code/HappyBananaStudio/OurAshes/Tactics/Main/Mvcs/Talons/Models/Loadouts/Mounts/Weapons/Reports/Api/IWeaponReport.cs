using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Traits.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Reports.Api
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
        IWeaponTraitReport GetWeaponTraitReport();
    }
}