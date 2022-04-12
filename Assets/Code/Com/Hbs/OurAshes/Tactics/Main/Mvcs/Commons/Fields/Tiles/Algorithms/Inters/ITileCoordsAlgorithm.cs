using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITileCoordsAlgorithm
    {
        ISet<Vector3> GetTileCoords(FieldShape fieldShape, FieldSize fieldSize);
    }
}