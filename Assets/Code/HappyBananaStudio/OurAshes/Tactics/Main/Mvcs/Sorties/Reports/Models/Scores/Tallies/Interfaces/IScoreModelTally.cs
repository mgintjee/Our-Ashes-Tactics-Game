using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Tallies.Interfaces
{
    /// <summary>
    /// Score Model Tally Interface
    /// </summary>
    public interface IScoreModelTally : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        PhalanxCallSign GetPhalanxCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetScore();
    }
}