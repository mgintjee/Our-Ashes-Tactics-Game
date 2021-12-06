using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controllers.AIs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controllers.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controllers.Engagements.Phalanxes.Inters
{
    /// <summary>
    /// Phalanx Controller Construction Interface
    /// </summary>
    public interface IPhalanxControllerConstruction
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
        ControllerID GetControllerType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        AIType GetAIType();
    }
}