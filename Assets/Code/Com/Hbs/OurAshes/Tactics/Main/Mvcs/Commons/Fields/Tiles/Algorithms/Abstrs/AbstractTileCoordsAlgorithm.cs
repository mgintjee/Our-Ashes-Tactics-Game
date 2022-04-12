using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractTileCoordsAlgorithm
        : ITileCoordsAlgorithm
    {
        ISet<Vector3> ITileCoordsAlgorithm.GetTileCoords(FieldShape fieldShape, FieldSize fieldSize)
        {
            int expectedTileCount = FieldShapeTileCountManager.GetTileCounts(fieldShape, fieldSize);
            ISet<Vector3> tileCoords = new HashSet<Vector3>();
            IList<Vector3> perimeterTileCoords = new List<Vector3>() { Vector3.Zero };
            while (perimeterTileCoords.Count != 0 && tileCoords.Count < expectedTileCount)
            {
                GetNextTileCoord(tileCoords, perimeterTileCoords).IfPresent(tileCoord =>
                {
                    ProcessTileCoord(tileCoords, perimeterTileCoords, tileCoord);
                });
            }

            return tileCoords;
        }
        protected abstract Optional<Vector3> GetNextTileCoord(ISet<Vector3> tileCoords, IList<Vector3> perimeterTileCoords);

        private void ProcessTileCoord(ISet<Vector3> tileCoords, IList<Vector3> perimeterTileCoords, Vector3 tileCoord)
        {
            tileCoords.Add(tileCoord);
            perimeterTileCoords.Remove(tileCoord);
            IList<Vector3> validNeighbors = GetNeighborsTileCoords(tileCoord, tileCoords);
            foreach (Vector3 neighborTileCoords in validNeighbors)
            {
                if (!tileCoords.Contains(neighborTileCoords))
                {
                    perimeterTileCoords.Add(neighborTileCoords);
                }
            }
        }

        private IList<Vector3> GetNeighborsTileCoords(Vector3 tileCoord, ISet<Vector3> tileCoords)
        {
            IList<Vector3> neighborTileCoords = new List<Vector3>
            {
                BuildNorthTile(tileCoord),
                BuildNorthEastTile(tileCoord),
                BuildSouthEastTile(tileCoord),
                BuildSouthTile(tileCoord),
                BuildSouthWestTile(tileCoord),
                BuildNorthWestTile(tileCoord)
            };

            foreach(Vector3 neighborTileCoord in neighborTileCoords)
            {
                if(tileCoords .Contains(neighborTileCoord))
                {
                    neighborTileCoords.Remove(neighborTileCoord);
                }
            }

            return neighborTileCoords;
        }

        private Vector3 BuildNorthTile(Vector3 vector3)
        {
            return new Vector3(vector3.X + 1, vector3.Y, vector3.Z - 1);
        }

        private Vector3 BuildNorthEastTile(Vector3 vector3)
        {
            return new Vector3(vector3.X + 1, vector3.Y - 1, vector3.Z);
        }

        private Vector3 BuildSouthEastTile(Vector3 vector3)
        {
            return new Vector3(vector3.X, vector3.Y - 1, vector3.Z + 1);
        }

        private Vector3 BuildSouthTile(Vector3 vector3)
        {
            return new Vector3(vector3.X - 1, vector3.Y, vector3.Z + 1);
        }

        private Vector3 BuildSouthWestTile(Vector3 vector3)
        {
            return new Vector3(vector3.X - 1, vector3.Y + 1, vector3.Z);
        }

        private Vector3 BuildNorthWestTile(Vector3 vector3)
        {
            return new Vector3(vector3.X - 1, vector3.Y + 1, vector3.Z);
        }
    }
}