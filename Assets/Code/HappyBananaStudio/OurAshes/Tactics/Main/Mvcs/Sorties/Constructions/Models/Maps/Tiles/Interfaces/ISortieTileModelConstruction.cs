using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Tiles.IDs;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Maps.Tiles.Interfaces
{
    /// <summary>
    /// Sortie Tile Model Construction Interface
    /// </summary>
    public interface ISortieTileModelConstruction : IReport
    {
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantCallSign GetCombatantCallSign();
    }
}