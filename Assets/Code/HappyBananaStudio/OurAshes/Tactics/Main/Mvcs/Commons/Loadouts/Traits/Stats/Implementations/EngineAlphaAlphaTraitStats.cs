using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Implementations.Abstracts;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Implementations
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
            _traitID = TraitID.EngineAlphaAlpha;
            _name = _traitID.ToString();
            // Model Stats
            _rarity = Rarity.Common;
            _traitType = TraitType.EngineAlpha;
            _combatantAttributes = new CombatantAttributes.Builder()
                .Build();
        }
    }
}