using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonRosterReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<TalonCallSign> GetActiveTalonCallSignSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IDictionary<TalonCallSign, ITalonReport> GetTalonCallSignReportDictionary();
    }
}