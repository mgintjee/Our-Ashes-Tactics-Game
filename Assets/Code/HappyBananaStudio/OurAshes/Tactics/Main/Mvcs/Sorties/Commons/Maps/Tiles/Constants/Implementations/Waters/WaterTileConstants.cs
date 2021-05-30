using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Waters
{
    /// <summary>
    /// Water Tile Constants Implementation
    /// </summary>
    public class WaterTileConstants
        : AbstractTileConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        public WaterTileConstants()
        {
            this.tileType = TileType.Water;
            this.initialCount = 1;
        }
    }
}