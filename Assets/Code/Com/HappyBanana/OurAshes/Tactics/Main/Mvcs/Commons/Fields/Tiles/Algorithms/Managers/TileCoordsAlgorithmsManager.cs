using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Hexs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TileCoordsAlgorithmsManager
    {
        private static readonly IDictionary<FieldShape, ITileCoordsAlgorithm> FIELD_SHAPE_TILE_ALGORITHMS =
            new Dictionary<FieldShape, ITileCoordsAlgorithm>()
            {
                { FieldShape.Hexagon, new HexTileCoordsAlgorithmImpl() },
                { FieldShape.Square, new HexTileCoordsAlgorithmImpl() }
            };

        public static Optional<ITileCoordsAlgorithm> GetTileCoordsAlgorithm(FieldShape fieldShape)
        {
            return (FIELD_SHAPE_TILE_ALGORITHMS.ContainsKey(fieldShape))
                ? Optional<ITileCoordsAlgorithm>.Of(FIELD_SHAPE_TILE_ALGORITHMS[fieldShape])
                : Optional<ITileCoordsAlgorithm>.Empty();
        }
    }
}