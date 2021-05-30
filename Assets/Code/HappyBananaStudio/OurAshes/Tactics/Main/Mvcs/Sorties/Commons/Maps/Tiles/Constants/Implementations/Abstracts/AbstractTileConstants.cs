using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Tile Stats Implementation
    /// </summary>
    public abstract class AbstractTileConstants
        : ITileConstants
    {
        // Todo
        protected int initialCount;

        // Todo
        protected TileType tileType;

        int ITileConstants.GetInitialCount()
        {
            return this.initialCount;
        }

        TileType ITileConstants.GetTileType()
        {
            return this.tileType;
        }
    }
}