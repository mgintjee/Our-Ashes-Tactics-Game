using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Models.Interfaces
{
    /// <summary>
    /// Trait Model Stats Interface
    /// </summary>
    public interface ITraitModelStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantAttributes GetCombatantAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TraitType GetTraitType();
    }
}