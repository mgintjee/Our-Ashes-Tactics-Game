using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Hexs.Utils
{
    public class HexTileCoordsUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static ISet<Vector3> GetTileCoordsForLayer(int layer)
        {
            logger.Debug("Getting TileCoords for Layer: {}", layer);
            ISet<Vector3> tileCoords = new HashSet<Vector3>();
            AddTileCoordsForLayerAlongAxisX(layer, tileCoords);
            AddTileCoordsForLayerAlongAxisY(layer, tileCoords);
            AddTileCoordsForLayerAlongAxisZ(layer, tileCoords);
            logger.Debug("For Layer: {}, TileCoords: {}", layer, tileCoords);
            return tileCoords;
        }

        public static int GetExpectedTileCoordsForLayer(int layer)
        {
            if (layer == 0)
            {
                return 1;
            }
            else
            {
                return 6 * layer + GetExpectedTileCoordsForLayer(layer - 1);
            }
        }

        private static void AddTileCoordsForLayerAlongAxisX(int layer, ISet<Vector3> tileCoords)
        {
            int x = layer;
            for (int i = 0; i < layer + 1; ++i)
            {
                int z = -i;
                int y = -x + i;
                Vector3 tileCoord = TileCoordsUtil.BuildTileCoord(x, y, z);
                TileCoordsUtil.AddPosAndNegTileCoords(tileCoords, tileCoord);
            }
        }

        private static void AddTileCoordsForLayerAlongAxisY(int layer, ISet<Vector3> tileCoords)
        {
            int y = layer;
            for (int i = 0; i < layer + 1; ++i)
            {
                int z = -i;
                int x = -y + i;
                Vector3 tileCoord = TileCoordsUtil.BuildTileCoord(x, y, z);
                TileCoordsUtil.AddPosAndNegTileCoords(tileCoords, tileCoord);
            }
        }

        private static void AddTileCoordsForLayerAlongAxisZ(int layer, ISet<Vector3> tileCoords)
        {
            int z = layer;
            for (int i = 0; i < layer + 1; ++i)
            {
                int x = -i;
                int y = -z + i;
                Vector3 tileCoord = TileCoordsUtil.BuildTileCoord(x, y, z);
                TileCoordsUtil.AddPosAndNegTileCoords(tileCoords, tileCoord);
            }
        }
    }
}