using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Models.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Models.Implementations
{
    /// <summary>
    /// Trait Model Stats Implementation
    /// </summary>
    public struct TraitModelStats
        : ITraitModelStats
    {
        // Todo
        private readonly TraitType _traitType;

        // Todo
        private readonly ICombatantAttributes _combatantAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitType">          </param>
        /// <param name="combatantAttributes"></param>
        private TraitModelStats(TraitType traitType, ICombatantAttributes combatantAttributes)
        {
            _traitType = traitType;
            _combatantAttributes = combatantAttributes;
        }

        /// <inheritdoc/>
        ICombatantAttributes ITraitModelStats.GetCombatantAttributes()
        {
            return _combatantAttributes;
        }

        /// <inheritdoc/>
        TraitType ITraitModelStats.GetTraitType()
        {
            return _traitType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TraitType _traitType;

            // Todo
            private ICombatantAttributes _combatantAttributes;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITraitModelStats Build()
            {
                return new TraitModelStats(_traitType, _combatantAttributes);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="traitType"></param>
            /// <returns></returns>
            public Builder SetTraitType(TraitType traitType)
            {
                _traitType = traitType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantAttributes"></param>
            /// <returns></returns>
            public Builder SetCombatantAttributes(ICombatantAttributes combatantAttributes)
            {
                _combatantAttributes = combatantAttributes;
                return this;
            }
        }
    }
}