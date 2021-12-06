using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Phalanxes.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Engagements.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IEngagementReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        EngagementType GetEngagementType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<PhalanxCallSign> GetActivePhalanxCallSigns();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<PhalanxCallSign> GetAllPhalanxCallSigns();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxCallSign"></param>
        /// <returns></returns>
        Optional<IPhalanxReport> GetPhalanxReport(PhalanxCallSign phalanxCallSign);
    }
}