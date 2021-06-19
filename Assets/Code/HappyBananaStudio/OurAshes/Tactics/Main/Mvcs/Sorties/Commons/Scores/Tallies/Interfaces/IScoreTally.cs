using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IScoreTally
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
        float GetScoreTally();
    }
}