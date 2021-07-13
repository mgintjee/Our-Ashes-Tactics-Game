using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Interfaces
{
    /// <summary>
    /// Sortie Tile Model Interface
    /// </summary>
    public interface ISortieTileModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieTileReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantCallSign"></param>
        void SetCombatantCallSign(CombatantCallSign combatantCallSign);
    }
}