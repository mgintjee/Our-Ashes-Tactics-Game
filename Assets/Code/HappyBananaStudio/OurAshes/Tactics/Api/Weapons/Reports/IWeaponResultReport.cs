/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IWeaponResultReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetHealthDamageCaused();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetArmorDamageCaused();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IWeaponOrderReport GetWeaponOrderReport();
    }
}
