using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Characteristics.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Movables.Interfaces
{
    /// <summary>
    /// Movable Model Interface
    /// </summary>
    public interface IMovableModel
        : ICharacteristicModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMovableAttributes GetCurrentAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMovableAttributes GetMaximumAttributes();
    }
}