using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Models.States.Inters
{
    public interface IQSortieMenuModelState
        : IMvcModelState
    {
        ISet<CombatantCallSign> GetCombatantCallSigns();

        IDictionary<CombatantCallSign, CombatantID> GetCombatantCallSignIDs();
    }
}