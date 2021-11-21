using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Interfaces
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