using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Interfaces
{
    /// <summary>
    /// Trait Stats Interface
    /// </summary>
    public interface ITraitStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TraitID GetTraitID();

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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Rarity GetRarity();
    }
}