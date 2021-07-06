using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Forests
{
    /// <summary>
    /// Forest Tile Stats Implementation
    /// </summary>
    public class ForestTileStats
        : AbstractTileStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public ForestTileStats()
        {
            _tileType = TileType.Forest;
            _tileAttributes = new TileAttributes.Builder()
                .SetFireCost(20)
                .SetMoveCost(3)
                .Build();
        }
    }
}