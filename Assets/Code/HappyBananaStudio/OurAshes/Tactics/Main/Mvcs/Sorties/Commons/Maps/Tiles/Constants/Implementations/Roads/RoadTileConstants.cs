using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Roads
{
    /// <summary>
    /// Road Tile Constants Implementation
    /// </summary>
    public class RoadTileConstants
        : AbstractTileConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        public RoadTileConstants()
        {
            this.tileType = TileType.Road;
            this.initialCount = 1;
        }
    }
}