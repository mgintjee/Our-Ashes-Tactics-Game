using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Interfaces
{
    /// <summary>
    /// Sortie Tile Model Interface
    /// </summary>
    public interface ITileModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITileReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantCallSign"></param>
        void SetCombatantCallSign(CombatantCallSign combatantCallSign);
    }
}