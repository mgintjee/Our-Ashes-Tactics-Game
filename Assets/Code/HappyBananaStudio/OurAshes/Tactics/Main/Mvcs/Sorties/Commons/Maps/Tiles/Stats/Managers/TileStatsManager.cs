using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Forests;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Mountains;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Roads;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Steppes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Implementations.Waters;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TileStatsManager
    {
        // Todo
        private static readonly ISet<ITileStats> TileStats =
            new HashSet<ITileStats>()
            {
                new ForestTileStats(),
                new MountainTileStats(),
                new RoadTileStats(),
                new SteppeTileStats(),
                new WaterTileStats()
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieTileType"></param>
        /// <returns></returns>
        public static ITileStats GetTileStats(TileType sortieTileType)
        {
            foreach (ITileStats stats in TileStats)
            {
                if (sortieTileType == stats.GetTileType())
                {
                    return stats;
                }
            }

            throw ExceptionUtil.Arguments.Build("Unable to {}. Invalid Parameters. {} is not supported.",
                new StackFrame().GetMethod().Name, sortieTileType);
        }
    }
}