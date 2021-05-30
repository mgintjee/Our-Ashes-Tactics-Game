using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Mountains
{
    /// <summary>
    /// Mountain Tile Constants Implementation
    /// </summary>
    public class MountainTileConstants
        : AbstractTileConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        public MountainTileConstants()
        {
            this.tileType = TileType.Mountain;
            this.initialCount = 1;
        }
    }
}