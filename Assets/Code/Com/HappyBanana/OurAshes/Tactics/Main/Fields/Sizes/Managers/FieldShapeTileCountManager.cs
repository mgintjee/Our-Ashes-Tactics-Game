using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FieldShapeTileCountManager
    {
        private static readonly IDictionary<FieldShape, IDictionary<FieldSize, int>> FIELD_SHAPE_TILE_COUNTS =
            new Dictionary<FieldShape, IDictionary<FieldSize, int>>()
            {
                { FieldShape.Hexagon, GetHexagonTileCounts() },
                { FieldShape.Square, GetHexagonTileCounts() }
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
            fieldSizeTileCounts.Add(FieldSize.Small, 1 + 6 + 12);
            fieldSizeTileCounts.Add(FieldSize.Medium, fieldSizeTileCounts[FieldSize.Small] + 18);
            fieldSizeTileCounts.Add(FieldSize.Large, fieldSizeTileCounts[FieldSize.Medium] + 24);
            return fieldSizeTileCounts;
        }
    }
}