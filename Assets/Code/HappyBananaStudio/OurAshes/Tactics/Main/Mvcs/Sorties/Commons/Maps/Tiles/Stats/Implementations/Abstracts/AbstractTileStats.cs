using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Tile Stats Implementation
    /// </summary>
    public abstract class AbstractTileStats
        : ITileStats
    {
        // Todo
        protected ITileAttributes tileAttributes;

        // Todo
        protected TileType tileType;

        /// <inheritdoc/>
        ITileAttributes ITileStats.GetTileAttributes()
        {
            return this.tileAttributes;
        }

        /// <inheritdoc/>
        TileType ITileStats.GetTileType()
        {
            return this.tileType;
        }
    }
}