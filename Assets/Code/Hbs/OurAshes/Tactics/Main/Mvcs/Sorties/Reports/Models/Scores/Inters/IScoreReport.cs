using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Scores.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Tallies.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IScoreReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<PhalanxCallSign> GetPhalanxCallSigns();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ScoreType GetScoreType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Optional<IScoreModelTally> GetTallyReport(PhalanxCallSign phalanxCallSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsScoreReached();
    }
}