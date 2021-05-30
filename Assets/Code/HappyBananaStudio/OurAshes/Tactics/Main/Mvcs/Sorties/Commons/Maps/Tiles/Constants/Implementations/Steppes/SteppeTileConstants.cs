using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Steppes
{
    /// <summary>
    /// Steppe Tile Constants Implementation
    /// </summary>
    public class SteppeTileConstants
        : AbstractTileConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        public SteppeTileConstants()
        {
            this.tileType = TileType.Steppe;
            this.initialCount = 1;
        }
    }
}