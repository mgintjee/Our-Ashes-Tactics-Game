namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Reports.Api;
    using System.Collections.Generic;

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