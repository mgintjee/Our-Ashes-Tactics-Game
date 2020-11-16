

namespace HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IWeaponInformationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IWeaponAttributes GetWeaponAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        WeaponModelId GetWeaponModelId();
    }
}
