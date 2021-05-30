using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Models.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Interfaces
{
    /// <summary>
    /// Trait Stats Interface
    /// </summary>
    public interface ITraitStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TraitID GetTraitID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITraitModelStats GetTraitModelStats();
    }
}