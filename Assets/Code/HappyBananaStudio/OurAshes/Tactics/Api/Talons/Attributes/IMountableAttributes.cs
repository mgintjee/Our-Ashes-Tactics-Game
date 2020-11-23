namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMountableAttributes
    {
        /// <summary>
        /// Get the UtiltyMountPoints
        /// </summary>
        /// <returns>
        /// The int UtiltyMountPoints
        /// </returns>
        int GetUtilityMountPoints();

        /// <summary>
        /// Get the WeaponMountPoints
        /// </summary>
        /// <returns>
        /// The int WeaponMountPoints
        /// </returns>
        int GetWeaponMountPoints();
    }
}