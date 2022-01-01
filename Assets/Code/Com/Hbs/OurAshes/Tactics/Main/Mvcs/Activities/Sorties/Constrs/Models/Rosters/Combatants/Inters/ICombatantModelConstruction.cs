using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Loadouts.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Rosters.Combatants.Inters
{
    /// <summary>
    /// Combatant Model Construction Interface
    /// </summary>
    public interface ICombatantModelConstruction
    {
        CombatantCallSign GetCombatantCallSign();

        CombatantID GetCombatantID();

        ILoadoutReport GetLoadoutReport();
    }
}