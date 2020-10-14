
namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Scripts
{
    using UnityEngine;

    /// <summary>
    /// TalonMounts Script Api
    /// </summary>
    public interface ITalonMountsScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetUtilityMountCount();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <returns>
        /// </returns>
        GameObject GetUtilityMountGameObject(int index);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetWeaponMountCount();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <returns>
        /// </returns>
        GameObject GetWeaponMountGameObject(int index);
    }
}
