using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Roads
{
    /// <summary>
    /// Road Tile Stats Implementation
    /// </summary>
    public class RoadTileStats
        : AbstractTileStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public RoadTileStats()
        {
            this.tileType = TileType.Road;
            this.tileAttributes = new TileAttributes.Builder()
                .SetFireCost(0)
                .SetMoveCost(1)
                .Build();
        }
    }
}