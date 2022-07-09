using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Utils
{
    public class TileCoordsUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static Vector3 BuildTileCoord(int x, int y, int z)
        {
            return new Vector3(x, z, y);
        }

        public static void AddPosAndNegTileCoords(IList<Vector3> tileCoords, Vector3 tileCoord)
        {
            tileCoords.Add(tileCoord);
            tileCoords.Add(-tileCoord);
        }

        public static bool IsSubsetOf(IList<Vector3> tileCoords, IList<Vector3> subTileCoords)
        {
            //logger.Debug("Checking if {} is subset of {}", subTileCoords, tileCoords);
            foreach (Vector3 subTileCoord in subTileCoords)
            {
                if (!tileCoords.Contains(subTileCoord))
                {
                    return false;
                }
            }
            return true;
        }
    }
}