using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Loadouts.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Rosters.Combatants.Interfaces
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