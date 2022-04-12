using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Abstrs;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HexagonTileCoordsAlgorithmImpl
        : AbstractTileCoordsAlgorithm
    {
        private readonly int MAX_HEX_LAYER = 9;
        protected override Optional<Vector3> GetNextTileCoord(ISet<Vector3> tileCoords, IList<Vector3> perimeterTileCoords)
        {
            ISet<Vector3> unfinishedLayer = this.GetMaxUnfinishedLayer(tileCoords);

            foreach(Vector3 tileCoord in unfinishedLayer)
            {
                if(!tileCoords.Contains(tileCoord) && perimeterTileCoords.Contains(tileCoord))
                {
                    return Optional<Vector3>.Of(tileCoord);
                }
            }

            return Optional<Vector3>.Empty();
        }

        private ISet<Vector3> GetMaxUnfinishedLayer(ISet<Vector3> tileCoords)
        {
            for(int i = 0; i < MAX_HEX_LAYER; ++i)
            {
                int expectedTileCoordsForLayer = this.GetExpectedTileCoordsForLayer(i);
                ISet<Vector3> layerTileCoords = this.GetTileCoordsForLayer(i);
                if(expectedTileCoordsForLayer == layerTileCoords.Count && !this.IsSubsetOf(tileCoords, layerTileCoords))
                {
                    return layerTileCoords;
                }
            }
            return new HashSet<Vector3>();
        }

        private bool IsSubsetOf(ISet<Vector3> tileCoords, ISet<Vector3> subTileCoords)
        {
            foreach(Vector3 subTileCoord in subTileCoords)
            {
                if(!tileCoords.Contains(subTileCoord))
                {
                    return false;
                }
            }
            return true;
        }

        private int GetExpectedTileCoordsForLayer(int layer)
        {
            if(layer == 0)
            {
                return 1;
            }
            else
            {
                return 6 * layer + GetExpectedTileCoordsForLayer(layer);
            }
        }

        private ISet<Vector3> GetTileCoordsForLayer(int layer)
        {
            ISet<Vector3> tileCoords = new HashSet<Vector3>();

            foreach (Vector3 tileCoord in this.GetAdjustedTileCoordsForX(layer))
            {
                tileCoords.Add(tileCoord);
            }
            foreach (Vector3 tileCoord in this.GetAdjustedTileCoordsForY(layer))
            {
                tileCoords.Add(tileCoord);
            }
            foreach (Vector3 tileCoord in this.GetAdjustedTileCoordsForZ(layer))
            {
                tileCoords.Add(tileCoord);
            }

            return tileCoords;
        }

        private ISet<Vector3> GetAdjustedTileCoordsForX(int layer)
        {
            ISet<Vector3> tileCoords = new HashSet<Vector3>();

            for(int i = 0; i < layer; ++i)
            {
                int adjustedY = 0;
                int adjustedZ = layer - i;
                this.AddTileCoordAndNegatedTileCoord(tileCoords, layer, adjustedY, adjustedZ);
            }

            return tileCoords;
        }
        private ISet<Vector3> GetAdjustedTileCoordsForY(int layer)
        {
            ISet<Vector3> tileCoords = new HashSet<Vector3>();

            for (int i = 0; i < layer; ++i)
            {
                int adjustedX = 0;
                int adjustedZ = layer - i;
                this.AddTileCoordAndNegatedTileCoord(tileCoords, adjustedX, layer, adjustedZ);
            }

            return tileCoords;
        }
        private ISet<Vector3> GetAdjustedTileCoordsForZ(int layer)
        {
            ISet<Vector3> tileCoords = new HashSet<Vector3>();

            for (int i = 0; i < layer; ++i)
            {
                int adjustedX = 0;
                int adjustedY = layer - i;
                this.AddTileCoordAndNegatedTileCoord(tileCoords, adjustedX, adjustedY, layer);
            }

            return tileCoords;
        }

        private void AddTileCoordAndNegatedTileCoord(ISet<Vector3 > tileCoords, int x, int y, int z)
        {
            Vector3 tileCoord = new Vector3(x, y, z);
            tileCoords.Add(tileCoord);
            tileCoords.Add(tileCoord * -1);
        }
    }
}