﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Interfaces
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