using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Models.Implementations;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Implementations
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
            this._traitID = TraitID.WeaponAlphaAlpha;
            this._name = _traitID.ToString();
            this._traitModelStats = new TraitModelStats.Builder()
                .SetTraitType(TraitType.WeaponAlpha)
                .SetCombatantAttributes(new CombatantAttributes.Builder()
                    .Build())
                .Build();
        }
    }
}