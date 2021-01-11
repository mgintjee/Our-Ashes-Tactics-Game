namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Attributes.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonLoadoutAttributes
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IArmorAttributes GetArmorAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngineAttributes GetEngineAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<MountSize> GetMountSizeList();
    }
}