namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Engines.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Engines.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Engine Object Api
    /// </summary>
    public interface IEngineObject
        : ILoadoutObject
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