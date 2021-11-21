using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Interfaces
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