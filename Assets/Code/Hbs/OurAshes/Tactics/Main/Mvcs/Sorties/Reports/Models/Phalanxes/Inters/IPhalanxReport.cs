using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controls.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Phalanxes.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPhalanxReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<CombatantCallSign> GetCombatantCallSigns();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ControlID GetControlType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        PhalanxCallSign GetPhalanxCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<PhalanxCallSign> GetPhalanxCallSigns();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        PhalanxType GetPhalanxType();
    }
}