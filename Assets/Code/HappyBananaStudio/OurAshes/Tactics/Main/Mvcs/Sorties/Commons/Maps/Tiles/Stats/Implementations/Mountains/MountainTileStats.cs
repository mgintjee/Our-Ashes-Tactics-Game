using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Mountains
{
    /// <summary>
    /// Mountain Tile Stats Implementation
    /// </summary>
    public class MountainTileStats
        : AbstractTileStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public MountainTileStats()
        {
            _tileType = TileType.Mountain;
            _tileAttributes = new TileAttributes.Builder()
                .SetFireCost(35)
                .SetMoveCost(4)
                .Build();
        }
    }
}