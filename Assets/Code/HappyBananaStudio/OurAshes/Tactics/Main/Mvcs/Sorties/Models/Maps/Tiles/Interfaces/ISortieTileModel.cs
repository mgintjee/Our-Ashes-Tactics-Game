using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Tiles.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Interfaces
{
    /// <summary>
    /// Sortie Tile Model Interface
    /// </summary>
    public interface ISortieTileModel
    {
        ISortieTileReport GetReport();

        void SetCombatantCallSign(CombatantCallSign combatantCallSign);
    }
}