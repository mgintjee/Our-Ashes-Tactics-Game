using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Waters
{
    /// <summary>
    /// Water Tile Stats Implementation
    /// </summary>
    public class WaterTileStats
        : AbstractTileStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public WaterTileStats()
        {
            this.tileType = TileType.Water;
            this.tileAttributes = new TileAttributes.Builder()
                .SetFireCost(5)
                .SetMoveCost(3)
                .Build();
        }
    }
}