﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Combatants.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Inters
{
    /// <summary>
    /// Combatant Model Interface
    /// </summary>
    public interface ICombatantModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        void ApplyCombatantAttributes(ICombatantAttributes combatantAttributes);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForPhase();
    }
}