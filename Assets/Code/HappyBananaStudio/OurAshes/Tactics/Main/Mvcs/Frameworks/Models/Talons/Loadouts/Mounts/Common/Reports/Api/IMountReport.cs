using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Reports.Api
{
    /// <summary>
    /// Mount Object Api
    /// </summary>
    public interface IMountReport
        : ILoadoutReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MountSize GetMountSize();
    }
}