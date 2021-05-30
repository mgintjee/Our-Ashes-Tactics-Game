using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Offset.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Offset.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Offset.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CoordinatesConvertorUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">     </param>
        /// <param name="offsetCoordinateType"></param>
        /// <returns></returns>
        public static IOffsetCoordinates CubeToOffset(ICubeCoordinates cubeCoordinates, OffsetCoordinateType offsetCoordinateType)
        {
            IOffsetCoordinates offsetCoordinates = null;
            switch (offsetCoordinateType)
            {
                case OffsetCoordinateType.ODD_R:
                    offsetCoordinates = CubeToOddr(cubeCoordinates);
                    break;

                case OffsetCoordinateType.EVEN_R:
                    offsetCoordinates = CubeToEvenr(cubeCoordinates);
                    break;

                case OffsetCoordinateType.ODD_Q:
                    offsetCoordinates = CubeToOddq(cubeCoordinates);
                    break;

                case OffsetCoordinateType.EVEN_Q:
                    offsetCoordinates = CubeToEvenq(cubeCoordinates);
                    break;

                default:
                    break;
            }
            return offsetCoordinates;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="offsetCoordinates"></param>
        /// <returns></returns>
        public static ICubeCoordinates OffsetToCube(IOffsetCoordinates offsetCoordinates)
        {
            ICubeCoordinates cubeCoordinates = null;
            OffsetCoordinateType offsetCoordinateType = offsetCoordinates.GetOffsetCoordinateType();
            int col = offsetCoordinates.GetCol();
            int row = offsetCoordinates.GetRow();
            switch (offsetCoordinateType)
            {
                case OffsetCoordinateType.ODD_R:
                    cubeCoordinates = OddrToCube(col, row);
                    break;

                case OffsetCoordinateType.EVEN_R:
                    cubeCoordinates = EvenrToCube(col, row);
                    break;

                case OffsetCoordinateType.ODD_Q:
                    cubeCoordinates = OddqToCube(col, row);
                    break;

                case OffsetCoordinateType.EVEN_Q:
                    cubeCoordinates = EvenqToCube(col, row);
                    break;

                default:
                    break;
            }
            return cubeCoordinates;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        private static IOffsetCoordinates CubeToEvenq(ICubeCoordinates cubeCoordinates)
        {
            int col = cubeCoordinates.GetX();
            int row = cubeCoordinates.GetZ() + (cubeCoordinates.GetX() + (cubeCoordinates.GetX() & 1)) / 2;
            return new OffsetCoordinates(col, row, OffsetCoordinateType.EVEN_Q);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        private static IOffsetCoordinates CubeToEvenr(ICubeCoordinates cubeCoordinates)
        {
            int col = cubeCoordinates.GetX() + (cubeCoordinates.GetZ() + (cubeCoordinates.GetZ() & 1)) / 2;
            int row = cubeCoordinates.GetZ();
            return new OffsetCoordinates(col, row, OffsetCoordinateType.EVEN_R);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        private static IOffsetCoordinates CubeToOddq(ICubeCoordinates cubeCoordinates)
        {
            int col = cubeCoordinates.GetX();
            int row = cubeCoordinates.GetZ() + (cubeCoordinates.GetX() - (cubeCoordinates.GetX() & 1)) / 2;
            return new OffsetCoordinates(col, row, OffsetCoordinateType.ODD_Q);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        private static IOffsetCoordinates CubeToOddr(ICubeCoordinates cubeCoordinates)
        {
            int col = cubeCoordinates.GetX() + (cubeCoordinates.GetZ() - (cubeCoordinates.GetZ() & 1)) / 2;
            int row = cubeCoordinates.GetZ();
            return new OffsetCoordinates(col, row, OffsetCoordinateType.ODD_R);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static ICubeCoordinates EvenqToCube(int col, int row)
        {
            int x = row;
            int z = col - (row + (row & 1)) / 2;
            int y = -x - z;
            return new CubeCoordinates(x, y, z);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static ICubeCoordinates EvenrToCube(int col, int row)
        {
            int x = col - (row + (row & 1)) / 2;
            int z = row;
            int y = -x - z;
            return new CubeCoordinates(x, y, z);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static ICubeCoordinates OddqToCube(int col, int row)
        {
            int x = row;
            int z = col - (row - (row & 1)) / 2;
            int y = -x - z;
            return new CubeCoordinates(x, y, z);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static ICubeCoordinates OddrToCube(int col, int row)
        {
            int x = col - (row - (row & 1)) / 2;
            int z = row;
            int y = -x - z;
            return new CubeCoordinates(x, y, z);
        }
    }
}