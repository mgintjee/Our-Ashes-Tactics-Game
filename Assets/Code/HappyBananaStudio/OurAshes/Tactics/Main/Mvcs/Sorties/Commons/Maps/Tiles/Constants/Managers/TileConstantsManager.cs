using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Forests;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Mountains;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Roads;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Steppes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Implementations.Waters;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TileConstantsManager
    {
        // Todo
        private static readonly ISet<ITileConstants> TileConstants =
            new HashSet<ITileConstants>()
            {
                new ForestTileConstants(),
                new MountainTileConstants(),
                new RoadTileConstants(),
                new SteppeTileConstants(),
                new WaterTileConstants()
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileType"></param>
        /// <returns></returns>
        public static ITileConstants GetTileConstants(TileType tileType)
        {
            foreach (ITileConstants constants in TileConstants)
            {
                if (tileType == constants.GetTileType())
                {
                    return constants;
                }
            }

            throw ExceptionUtil.Arguments.Build("Unable to {}. Invalid Parameters. {} is not supported.",
                new StackFrame().GetMethod().Name, tileType);
        }
    }
}