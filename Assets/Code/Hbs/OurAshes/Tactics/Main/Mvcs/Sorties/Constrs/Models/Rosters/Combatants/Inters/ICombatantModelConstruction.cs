using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Loadouts.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Rosters.Combatants.Inters
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