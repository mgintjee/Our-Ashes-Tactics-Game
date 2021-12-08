using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controls.AIs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controls.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controls.Engagements.Phalanxes.Inters
{
    /// <summary>
    /// Phalanx Control Construction Interface
    /// </summary>
    public interface IPhalanxControlConstruction
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
        AIType GetAIType();
    }
}