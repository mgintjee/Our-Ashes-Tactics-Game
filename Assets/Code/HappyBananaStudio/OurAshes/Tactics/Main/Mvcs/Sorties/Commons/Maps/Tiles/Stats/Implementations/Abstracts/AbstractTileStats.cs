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
        protected ITileAttributes _tileAttributes;

        // Todo
        protected TileType _tileType;

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}",
                this.GetType().Name, _tileAttributes);
        }

        /// <inheritdoc/>
        ITileAttributes ITileStats.GetTileAttributes()
        {
            return _tileAttributes;
        }

        /// <inheritdoc/>
        TileType ITileStats.GetTileType()
        {
            return _tileType;
        }
    }
}