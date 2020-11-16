namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;

    /// <summary>
    /// Destructible Object Api
    /// </summary>
    public interface IDestructibleObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDestructibleAttributesReport GetDestructibleAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorDamage">
        /// </param>
        /// <param name="healthDamage">
        /// </param>
        void InputDamage(int armorDamage, int healthDamage);
    }
}
