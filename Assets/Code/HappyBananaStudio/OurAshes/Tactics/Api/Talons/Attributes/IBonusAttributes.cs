
namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Attributes;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IBonusAttributes
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDestructibleAttributes GetDestructibleAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMovableAttributes GetMovableAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IWeaponAttributes GetWeaponAttributes();
    }
}
