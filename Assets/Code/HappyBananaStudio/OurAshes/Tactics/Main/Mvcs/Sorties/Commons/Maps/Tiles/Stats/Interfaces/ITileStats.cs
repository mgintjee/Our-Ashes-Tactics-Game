using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Interfaces
{
    /// <summary>
    /// Sortie Tile Stats Interface
    /// </summary>
    public interface ITileStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITileAttributes GetTileAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TileType GetTileType();
    }
}