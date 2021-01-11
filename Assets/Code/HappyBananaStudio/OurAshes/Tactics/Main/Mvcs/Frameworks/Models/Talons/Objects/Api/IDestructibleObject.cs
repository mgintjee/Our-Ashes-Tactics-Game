using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Attributes.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api
{
    /// <summary>
    /// Destructible Object Api
    /// </summary>
    public interface IDestructibleObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetCurrentHealthPoints();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetCurrentArmorPoints();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IArmorAttributes GetArmorAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorDamage"></param>
        /// <param name="healthDamage"></param>
        void InputDestructableCosts(float armorDamage, float healthDamage);

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewPhase();
    }
}