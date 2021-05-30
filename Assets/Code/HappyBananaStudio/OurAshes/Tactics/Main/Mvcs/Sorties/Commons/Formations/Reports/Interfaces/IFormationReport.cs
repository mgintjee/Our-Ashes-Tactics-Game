using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Formations.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Formations.Reports.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IFormationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        FormationType GetFormation();

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