using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Coords.Offsets.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Coords.Offsets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Coords.Offsets.Types;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Coords.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CoordsConvertorUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeVector3">         </param>
        /// <param name="offsetCoordinateType"></param>
        /// <returns></returns>
        public static IOffsetCoords CubeToOffset(Vector3 cubeVector3, OffsetCoordsType offsetCoordinateType)
        {
            IOffsetCoords offsetCoordinates = null;
            switch (offsetCoordinateType)
            {
                case OffsetCoordsType.ODD_R:
                    offsetCoordinates = CubeToOddr(cubeVector3);
                    break;

                case OffsetCoordsType.EVEN_R:
                    offsetCoordinates = CubeToEvenr(cubeVector3);
                    break;

                case OffsetCoordsType.ODD_Q:
                    offsetCoordinates = CubeToOddq(cubeVector3);
                    break;

                case OffsetCoordsType.EVEN_Q:
                    offsetCoordinates = CubeToEvenq(cubeVector3);
                    break;

                default:
                    break;
            }
            return offsetCoordinates;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="offsetCoords"></param>
        /// <returns></returns>
        public static Vector3 OffsetToCube(IOffsetCoords offsetCoords)
        {
            Vector3 cubeVector3 = new Vector3();
            OffsetCoordsType offsetCoordinateType = offsetCoords.GetOffsetCoordsType();
            int col = (int)offsetCoords.GetCoords().X;
            int row = (int)offsetCoords.GetCoords().Y;
            switch (offsetCoordinateType)
            {
                case OffsetCoordsType.ODD_R:
                    cubeVector3 = OddrToCube(col, row);
                    break;

                case OffsetCoordsType.EVEN_R:
                    cubeVector3 = EvenrToCube(col, row);
                    break;

                case OffsetCoordsType.ODD_Q:
                    cubeVector3 = OddqToCube(col, row);
                    break;

                case OffsetCoordsType.EVEN_Q:
                    cubeVector3 = EvenqToCube(col, row);
                    break;

                default:
                    break;
            }
            return cubeVector3;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeVector3"></param>
        /// <returns></returns>
        private static IOffsetCoords CubeToEvenq(Vector3 cubeVector3)
        {
            int col = (int)cubeVector3.X;
            int row = (int)(cubeVector3.Z + (cubeVector3.X + (col & 1)) / 2);
            return OffsetCoordsImpl.Builder.Get()
                .SetVector2(new Vector2(col, row))
                .SetOffsetCoordsType(OffsetCoordsType.EVEN_Q)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        private static IOffsetCoords CubeToEvenr(Vector3 cubeCoordinates)
        {
            int row = (int)cubeCoordinates.Z;
            int col = (int)(cubeCoordinates.X + (cubeCoordinates.Z + (row & 1)) / 2);
            return OffsetCoordsImpl.Builder.Get()
                .SetVector2(new Vector2(col, row))
                .SetOffsetCoordsType(OffsetCoordsType.EVEN_R)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        private static IOffsetCoords CubeToOddq(Vector3 cubeCoordinates)
        {
            int col = (int)cubeCoordinates.X;
            int row = (int)(cubeCoordinates.Z + (cubeCoordinates.X - (col & 1)) / 2);
            return OffsetCoordsImpl.Builder.Get()
                .SetVector2(new Vector2(col, row))
                .SetOffsetCoordsType(OffsetCoordsType.ODD_Q)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        private static IOffsetCoords CubeToOddr(Vector3 cubeCoordinates)
        {
            int row = (int)cubeCoordinates.Z;
            int col = (int)(cubeCoordinates.X + (cubeCoordinates.Z - (row & 1)) / 2);
            return OffsetCoordsImpl.Builder.Get()
                .SetVector2(new Vector2(col, row))
                .SetOffsetCoordsType(OffsetCoordsType.ODD_R)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static Vector3 EvenqToCube(int col, int row)
        {
            int x = row;
            int z = col - (row + (row & 1)) / 2;
            int y = -x - z;
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static Vector3 EvenrToCube(int col, int row)
        {
            int x = col - (row + (row & 1)) / 2;
            int z = row;
            int y = -x - z;
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static Vector3 OddqToCube(int col, int row)
        {
            int x = row;
            int z = col - (row - (row & 1)) / 2;
            int y = -x - z;
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static Vector3 OddrToCube(int col, int row)
        {
            int x = col - (row - (row & 1)) / 2;
            int z = row;
            int y = -x - z;
            return new Vector3(x, y, z);
        }
    }
}