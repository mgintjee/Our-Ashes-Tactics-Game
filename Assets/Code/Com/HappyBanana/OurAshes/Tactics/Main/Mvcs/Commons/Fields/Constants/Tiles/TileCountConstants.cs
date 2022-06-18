using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Tiles
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TileCountConstants
    {
        private static readonly int HEXAGON_LAYER_COUNT = 6;

        private static readonly IDictionary<FieldShape, IDictionary<FieldSize, int>> FIELD_SHAPE_TILE_COUNTS =
            new Dictionary<FieldShape, IDictionary<FieldSize, int>>()
            {
                { FieldShape.Hexagon, GetHexagonTileCounts() }
            };

        public static int GetTileCounts(FieldShape fieldShape, FieldSize fieldSize)
        {
            int tileCount = 0;

            if (FIELD_SHAPE_TILE_COUNTS.ContainsKey(fieldShape))
            {
                IDictionary<FieldSize, int> fieldSizeTileCounts = FIELD_SHAPE_TILE_COUNTS[fieldShape];
                if (fieldSizeTileCounts.ContainsKey(fieldSize))
                {
                    tileCount = fieldSizeTileCounts[fieldSize];
                }
            }

            return tileCount;
        }

        private static IDictionary<FieldSize, int> GetHexagonTileCounts()
        {
            IDictionary<FieldSize, int> fieldSizeTileCounts = new Dictionary<FieldSize, int>();
            fieldSizeTileCounts.Add(FieldSize.Small, 1 + HEXAGON_LAYER_COUNT * 3);
            fieldSizeTileCounts.Add(FieldSize.Medium, fieldSizeTileCounts[FieldSize.Small] + HEXAGON_LAYER_COUNT * 3);
            fieldSizeTileCounts.Add(FieldSize.Medium, fieldSizeTileCounts[FieldSize.Large] + HEXAGON_LAYER_COUNT * 4);
            return fieldSizeTileCounts;
        }
    }
}