using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Interfaces
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