namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Mounts.Utilities.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Mounts.Common.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Mounts.Utilities.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Mount Utility Object Api
    /// </summary>
    public interface IMountUtilityObject
        : ILoadoutObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        UtilityId GetUtilityId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MountSize GetMountSize();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        UtilityType GetUtilityType();
    }
}