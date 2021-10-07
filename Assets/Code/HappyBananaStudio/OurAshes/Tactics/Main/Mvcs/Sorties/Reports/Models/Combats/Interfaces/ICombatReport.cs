using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Damages.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combats.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICombatReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantCallSign GetActingCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantCallSign GetTargetCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<IDamageReport> GetDamageReports();
    }
}