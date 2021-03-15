using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Effects.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Attributes.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Subs.Destructibles.Api
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
        /// <param name="talonEffectObject"></param>
        void InputTalonEffect(ITalonEffectObject talonEffectObject);
    }
}