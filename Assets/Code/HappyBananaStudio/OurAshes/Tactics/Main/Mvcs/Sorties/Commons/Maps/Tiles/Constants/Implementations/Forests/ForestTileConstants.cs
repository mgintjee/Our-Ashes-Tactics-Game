using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Forests
{
    /// <summary>
    /// Forest Tile Constants Implementation
    /// </summary>
    public class ForestTileConstants
        : AbstractTileConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        public ForestTileConstants()
        {
            this.tileType = TileType.Forest;
            this.initialCount = 1;
        }
    }
}