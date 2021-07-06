using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Implementations.Abstracts;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Implementations
{
    /// <summary>
    /// Cabin Alpha Alpha Trait Stats Implementation
    /// </summary>
    public class CabinAlphaAlphaTraitStats
        : AbstractTraitStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public CabinAlphaAlphaTraitStats()
        {
            _traitID = TraitID.CabinAlphaAlpha;
            _name = _traitID.ToString();
            _rarity = Rarity.Common;
            _traitType = TraitType.CabinAlpha;
            // Model Stats
            _combatantAttributes = new CombatantAttributes.Builder()
                .Build();
        }
    }
}