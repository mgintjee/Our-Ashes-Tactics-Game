using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Reports.Api
{
    /// <summary>
    /// Engine Report Api
    /// </summary>
    public interface IEngineReport
        : ILoadoutReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        EngineId GetEngineId();

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