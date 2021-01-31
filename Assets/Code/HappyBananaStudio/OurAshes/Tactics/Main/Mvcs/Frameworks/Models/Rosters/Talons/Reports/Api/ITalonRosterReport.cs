namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using System.Collections.Generic;

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