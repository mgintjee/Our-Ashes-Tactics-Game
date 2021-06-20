using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Steppes
{
    /// <summary>
    /// Steppe Tile Stats Implementation
    /// </summary>
    public class SteppeTileStats
        : AbstractTileStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public SteppeTileStats()
        {
            this._tileType = TileType.Steppe;
            this._tileAttributes = new TileAttributes.Builder()
                .SetFireCost(5)
                .SetMoveCost(2)
                .Build();
        }
    }
}