using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Trait Stats Implementation
    /// </summary>
    public class AbstractTraitStats
        : ITraitStats
    {
        // Todo
        protected string _name;

        // Todo
        protected TraitID _traitID;

        // Todo
        protected TraitType _traitType;

        // Todo
        protected ICombatantAttributes _combatantAttributes;

        // Todo
        protected Rarity _rarity;

        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <inheritdoc/>
        ICombatantAttributes ITraitStats.GetCombatantAttributes()
        {
            return _combatantAttributes;
        }

        /// <inheritdoc/>
        string ITraitStats.GetName()
        {
            return _name;
        }

        /// <inheritdoc/>
        Rarity ITraitStats.GetRarity()
        {
            return _rarity;
        }

        /// <inheritdoc/>
        TraitID ITraitStats.GetTraitID()
        {
            return _traitID;
        }

        /// <inheritdoc/>
        TraitType ITraitStats.GetTraitType()
        {
            return _traitType;
        }
    }
}