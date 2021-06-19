using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Implementations.Abstracts;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Implementations
{
    /// <summary>
    /// Weapon Alpha Alpha Trait Stats Implementation
    /// </summary>
    public class WeaponAlphaAlphaTraitStats
        : AbstractTraitStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public WeaponAlphaAlphaTraitStats()
        {
            _traitID = TraitID.WeaponAlphaAlpha;
            _name = _traitID.ToString();
            _rarity = Rarity.Common;
            _traitType = TraitType.WeaponAlpha;
            // Model Stats
            _combatantAttributes = new CombatantAttributes.Builder()
                .Build();
        }
    }
}