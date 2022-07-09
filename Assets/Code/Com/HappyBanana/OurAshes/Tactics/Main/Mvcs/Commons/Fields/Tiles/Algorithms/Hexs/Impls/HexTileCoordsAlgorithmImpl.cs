using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Hexs.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Hexs.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileCoordsAlgorithmImpl
        : AbstractTileCoordsAlgorithm
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        private readonly int MAX_HEX_LAYER = 9;

        protected override Optional<Vector3> GetNextTileCoord(IList<Vector3> visitedTileCoords, IList<Vector3> unvisitedTileCoords)
        {
            IList<Vector3> unfinishedLayer = this.GetMaxUnfinishedLayer(visitedTileCoords);
            foreach (Vector3 tileCoord in unfinishedLayer)
            {
                if (!visitedTileCoords.Contains(tileCoord) && unvisitedTileCoords.Contains(tileCoord))
                {
                    /*
                    logger.Debug("Selected TileCoord: {}" +
                        "\nUnvisited Set: {}" +
                        "\nVisited Set: {}",
                        tileCoord, unvisitedTileCoords, visitedTileCoords);
                    */
                    return Optional<Vector3>.Of(tileCoord);
                }
            }

            return Optional<Vector3>.Empty();
        }

        private IList<Vector3> GetMaxUnfinishedLayer(IList<Vector3> tileCoords)
        {
            for (int i = 0; i < MAX_HEX_LAYER; ++i)
            {
                IList<Vector3> layerTileCoords = HexTileCoordsUtil.GetTileCoordsForLayer(i);
                if (!TileCoordsUtil.IsSubsetOf(tileCoords, layerTileCoords))
                {
                    //logger.Debug("Found unfinished layer: {}, TileCoords: {}", i, layerTileCoords);
                    return layerTileCoords;
                }
            }
            return new List<Vector3>();
        }
    }
}