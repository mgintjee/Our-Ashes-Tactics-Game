using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Traits.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Traits.Reports.Api
{
    /// <summary>
    /// Engine Trait Report Api
    /// </summary>
    public interface IEngineTraitReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        EngineTraitEfficiency GetEngineTraitEfficiency();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        EngineTraitStructure GetEngineTraitStructure();
    }
}