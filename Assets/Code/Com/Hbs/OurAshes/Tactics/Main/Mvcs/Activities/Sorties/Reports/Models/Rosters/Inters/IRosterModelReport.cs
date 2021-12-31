using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Inters
{
    /// <summary>
    /// Roster Model Report Interface
    /// </summary>
    public interface IRosterModelReport : IReport
    {
        ISet<CombatantCallSign> GetActiveCombatantCallSigns();

        ISet<CombatantCallSign> GetAllCombatantCallSigns();

        Optional<ICombatantReport> GetCombatantReport(CombatantCallSign combatantCallSign);
    }
}