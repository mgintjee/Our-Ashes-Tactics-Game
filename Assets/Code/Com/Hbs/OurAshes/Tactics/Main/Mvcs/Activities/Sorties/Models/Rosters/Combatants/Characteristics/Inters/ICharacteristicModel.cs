using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Characteristics.Inters
{
    /// <summary>
    /// Characteristic Model Interface
    /// </summary>
    public interface ICharacteristicModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        void ApplyCombatantAttributes(ICombatantAttributes combatantAttributes);

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForPhase();
    }
}