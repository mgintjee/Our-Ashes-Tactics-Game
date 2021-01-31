namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IPhalanxRosterReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<IPhalanxReport> GetPhalanxReports();
    }
}