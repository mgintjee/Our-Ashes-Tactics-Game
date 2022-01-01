﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Rosters.Combatants.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Rosters.Inters
{
    /// <summary>
    /// Roster Model Construction Interface
    /// </summary>
    public interface IRosterModelConstruction
    {
        ISet<ICombatantModelConstruction> GetCombatantModelConstrs();
    }
}