using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Implementations.Abstracts;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Implementations
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
            // Common Stats
            _traitID = TraitID.ArmorAlphaAlpha;
            _name = _traitID.ToString();
            // Model Stats
            _rarity = Rarity.Common;
            _traitType = TraitType.ArmorAlpha;
            _combatantAttributes = new CombatantAttributes.Builder()
                .Build();
        }
    }
}