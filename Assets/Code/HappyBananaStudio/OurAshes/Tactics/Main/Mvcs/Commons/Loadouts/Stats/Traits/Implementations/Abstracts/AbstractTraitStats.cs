using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Models.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Implementations.Abstracts
{
    /// <summary>
    /// Armor Alpha Alpha Trait Stats Implementation
    /// </summary>
    public class AbstractTraitStats
        : ITraitStats
    {
        // Todo
        protected string _name;

        // Todo
        protected ITraitModelStats _traitModelStats;

        // Todo
        protected TraitID _traitID;

        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <inheritdoc/>
        string ITraitStats.GetName()
        {
            return _name;
        }

        /// <inheritdoc/>
        TraitID ITraitStats.GetTraitID()
        {
            return _traitID;
        }

        /// <inheritdoc/>
        ITraitModelStats ITraitStats.GetTraitModelStats()
        {
            return _traitModelStats;
        }
    }
}