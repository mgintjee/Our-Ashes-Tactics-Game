using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractTileCoordsAlgorithm
        : ITileCoordsAlgorithm
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        ISet<Vector3> ITileCoordsAlgorithm.GetTileCoords(FieldShape fieldShape, FieldSize fieldSize)
        {
            int expectedTileCount = FieldShapeTileCountManager.GetTileCounts(fieldShape, fieldSize);
            ISet<Vector3> vistedTileCoords = new HashSet<Vector3>();
            IList<Vector3> unvisitedTileCoords = new List<Vector3>() { Vector3.Zero };
            logger.Info("Getting TileCoords for {} and {}. Expected TileCount: {}", fieldShape, fieldSize, expectedTileCount);
            while (unvisitedTileCoords.Count != 0 && vistedTileCoords.Count < expectedTileCount)
            {
                GetNextTileCoord(vistedTileCoords, unvisitedTileCoords).IfPresent(tileCoord =>
                {
                    ProcessTileCoord(vistedTileCoords, unvisitedTileCoords, tileCoord);
                });
            }

            return vistedTileCoords;
        }

        protected abstract Optional<Vector3> GetNextTileCoord(ISet<Vector3> visitedTileCoords, IList<Vector3> unvisitedTileCoords);

        private void ProcessTileCoord(ISet<Vector3> visitedTileCoords, IList<Vector3> unvisitedTileCoords, Vector3 tileCoord)
        {
            logger.Info("Processing TileCoord: {}", tileCoord);
            visitedTileCoords.Add(tileCoord);
            unvisitedTileCoords.Remove(tileCoord);
            IList<Vector3> validNeighbors = GetNeighborsTileCoords(tileCoord);
            foreach (Vector3 neighborTileCoords in validNeighbors)
            {
                if (!visitedTileCoords.Contains(neighborTileCoords))
                {
                    logger.Info("Adding TileCoord: {} to the unvisted coords", neighborTileCoords);
                    unvisitedTileCoords.Add(neighborTileCoords);
                }
            }
        }

        private IList<Vector3> GetNeighborsTileCoords(Vector3 tileCoord)
        {
            return new List<Vector3>
            {
                BuildNorthTile(tileCoord),
                BuildNorthEastTile(tileCoord),
                BuildSouthEastTile(tileCoord),
                BuildSouthTile(tileCoord),
                BuildSouthWestTile(tileCoord),
                BuildNorthWestTile(tileCoord)
            };
        }

        private Vector3 BuildNorthTile(Vector3 tileCoord)
        {
            return new Vector3(tileCoord.X + 1, tileCoord.Y, tileCoord.Z - 1);
        }

        private Vector3 BuildNorthEastTile(Vector3 tileCoord)
        {
            return new Vector3(tileCoord.X + 1, tileCoord.Y - 1, tileCoord.Z);
        }

        private Vector3 BuildSouthEastTile(Vector3 tileCoord)
        {
            return new Vector3(tileCoord.X, tileCoord.Y - 1, tileCoord.Z + 1);
        }

        private Vector3 BuildSouthTile(Vector3 tileCoord)
        {
            return new Vector3(tileCoord.X - 1, tileCoord.Y, tileCoord.Z + 1);
        }

        private Vector3 BuildSouthWestTile(Vector3 tileCoord)
        {
            return new Vector3(tileCoord.X - 1, tileCoord.Y + 1, tileCoord.Z);
        }

        private Vector3 BuildNorthWestTile(Vector3 tileCoord)
        {
            return new Vector3(tileCoord.X - 1, tileCoord.Y + 1, tileCoord.Z);
        }
    }
}