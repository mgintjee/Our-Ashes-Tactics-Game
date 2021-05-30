using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Types.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ScoreReport
        : IScoreReport
    {
        ISet<PhalanxCallSign> IScoreReport.GetPhalanxCallSigns()
        {
            throw new System.NotImplementedException();
        }

        ScoreType IScoreReport.GetScoreType()
        {
            throw new System.NotImplementedException();
        }

        Optional<ITallyReport> IScoreReport.GetTallyReport(PhalanxCallSign phalanxCallSign)
        {
            throw new System.NotImplementedException();
        }

        bool IScoreReport.IsScoreReached()
        {
            throw new System.NotImplementedException();
        }
    }
}