using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Tiles.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Maps.Tiles.Inters
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