﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITileCoordsAlgorithm
    {
        IList<Vector3> GetTileCoords(FieldShape fieldShape, FieldSize fieldSize);
    }
}