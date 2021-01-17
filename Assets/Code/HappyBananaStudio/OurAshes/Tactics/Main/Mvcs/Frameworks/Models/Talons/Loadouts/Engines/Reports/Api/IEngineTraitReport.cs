namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Enums;

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