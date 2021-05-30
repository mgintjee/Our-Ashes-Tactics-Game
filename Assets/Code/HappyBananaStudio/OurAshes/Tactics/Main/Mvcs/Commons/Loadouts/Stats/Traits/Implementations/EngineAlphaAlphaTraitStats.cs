using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Models.Implementations;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Implementations
{
    /// <summary>
    /// Engine Alpha Alpha Trait Stats Implementation
    /// </summary>
    public class EngineAlphaAlphaTraitStats
        : AbstractTraitStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public EngineAlphaAlphaTraitStats()
        {
            this._traitID = TraitID.EngineAlphaAlpha;
            this._name = _traitID.ToString();
            this._traitModelStats = new TraitModelStats.Builder()
                .SetTraitType(TraitType.EngineAlpha)
                .SetCombatantAttributes(new CombatantAttributes.Builder()
                    .Build())
                .Build();
        }
    }
}