using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Tiles.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Interfaces
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