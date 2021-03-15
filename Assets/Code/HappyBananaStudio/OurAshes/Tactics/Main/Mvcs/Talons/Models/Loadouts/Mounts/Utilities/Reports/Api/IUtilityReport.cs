using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Reports.Api
{
    /// <summary>
    /// Utility Report Api
    /// </summary>
    public interface IUtilityReport
        : IMountReport
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
        UtilityType GetUtilityType();
    }
}