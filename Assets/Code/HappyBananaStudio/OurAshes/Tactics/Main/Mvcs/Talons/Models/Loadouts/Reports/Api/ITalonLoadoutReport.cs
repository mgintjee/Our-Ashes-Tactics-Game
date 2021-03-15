using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Common.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Reports.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonLoadoutReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonId GetTalonId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IArmorReport GetArmorReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngineReport GetEngineReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<IMountReport> GetMountReportList();
    }
}