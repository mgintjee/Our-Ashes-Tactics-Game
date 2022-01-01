using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Maps.Tiles.Inters
{
    /// <summary>
    /// Sortie Tile Model Construction Interface
    /// </summary>
    public interface ISortieTileModelConstruction
    {
        ICubeCoordinates GetCubeCoordinates();

        SortieTileID GetSortieTileID();

        CombatantCallSign GetCombatantCallSign();
    }
}