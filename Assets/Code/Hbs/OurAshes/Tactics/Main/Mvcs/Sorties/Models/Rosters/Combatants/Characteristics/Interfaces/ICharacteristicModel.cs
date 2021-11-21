using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Characteristics.Interfaces
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