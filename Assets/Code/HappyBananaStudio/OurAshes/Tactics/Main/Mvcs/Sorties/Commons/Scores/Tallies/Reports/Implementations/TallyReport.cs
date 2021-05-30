using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Reports.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TallyReport
        : ITallyReport
    {
        PhalanxCallSign ITallyReport.GetPhalanxCallSign()
        {
            throw new System.NotImplementedException();
        }

        float ITallyReport.GetScoreTally()
        {
            throw new System.NotImplementedException();
        }
    }
}