using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Models.Implementations;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Implementations
{
    /// <summary>
    /// Armor Alpha Alpha Trait Stats Implementation
    /// </summary>
    public class ArmorAlphaAlphaTraitStats
        : AbstractTraitStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public ArmorAlphaAlphaTraitStats()
        {
            this._traitID = TraitID.ArmorAlphaAlpha;
            this._name = _traitID.ToString();
            this._traitModelStats = new TraitModelStats.Builder()
                .SetTraitType(TraitType.ArmorAlpha)
                .SetCombatantAttributes(new CombatantAttributes.Builder()
                    .Build())
                .Build();
        }
    }
}