using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scores.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces
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
        Optional<IScoreTally> GetTallyReport(PhalanxCallSign phalanxCallSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsScoreReached();
    }
}