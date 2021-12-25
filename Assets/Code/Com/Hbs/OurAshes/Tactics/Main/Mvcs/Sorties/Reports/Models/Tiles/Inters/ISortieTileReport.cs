using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Tiles.Inters
{
    /// <summary>
    /// Sortie Tile Report Interface
    /// </summary>
    public interface ISortieTileReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantCallSign GetCombatantCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICubeCoordinates GetCubeCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SortieTileID GetSortieTileID();
    }
}