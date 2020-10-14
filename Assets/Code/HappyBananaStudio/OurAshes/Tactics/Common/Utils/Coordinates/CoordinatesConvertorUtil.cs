

namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Coordinates
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Offset;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Coordinates;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Coordinates.Objects.Offset;

    /// <summary>
    /// Todo
    /// </summary>
    public static class CoordinatesConvertorUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <param name="offsetCoordinateType">
        /// </param>
        /// <returns>
        /// </returns>
        public static IOffsetCoordinates CubeToOffset(ICubeCoordinates cubeCoordinates, OffsetCoordinateTypeEnum offsetCoordinateType)
        {
            IOffsetCoordinates offsetCoordinates = null;
            switch (offsetCoordinateType)
            {
                case OffsetCoordinateTypeEnum.ODD_R:
                    offsetCoordinates = CubeToOddr(cubeCoordinates);
                    break;

                case OffsetCoordinateTypeEnum.EVEN_R:
                    offsetCoordinates = CubeToEvenr(cubeCoordinates);
                    break;

                case OffsetCoordinateTypeEnum.ODD_Q:
                    offsetCoordinates = CubeToOddq(cubeCoordinates);
                    break;

                case OffsetCoordinateTypeEnum.EVEN_Q:
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
        /// <param name="offsetCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static ICubeCoordinates OffsetToCube(IOffsetCoordinates offsetCoordinates)
        {
            ICubeCoordinates cubeCoordinates = null;
            OffsetCoordinateTypeEnum offsetCoordinateType = offsetCoordinates.GetOffsetCoordinateType();
            int col = offsetCoordinates.GetCol();
            int row = offsetCoordinates.GetRow();
            switch (offsetCoordinateType)
            {
                case OffsetCoordinateTypeEnum.ODD_R:
                    cubeCoordinates = OddrToCube(col, row);
                    break;

                case OffsetCoordinateTypeEnum.EVEN_R:
                    cubeCoordinates = EvenrToCube(col, row);
                    break;

                case OffsetCoordinateTypeEnum.ODD_Q:
                    cubeCoordinates = OddqToCube(col, row);
                    break;

                case OffsetCoordinateTypeEnum.EVEN_Q:
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
            return new OffsetCoordinatesImpl(col, row, OffsetCoordinateTypeEnum.EVEN_Q);
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
            return new OffsetCoordinatesImpl(col, row, OffsetCoordinateTypeEnum.EVEN_R);
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
            return new OffsetCoordinatesImpl(col, row, OffsetCoordinateTypeEnum.ODD_Q);
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
            return new OffsetCoordinatesImpl(col, row, OffsetCoordinateTypeEnum.ODD_R);
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
            return new CubeCoordinatesImpl(x, y, z);
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
            return new CubeCoordinatesImpl(x, y, z);
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
            return new CubeCoordinatesImpl(x, y, z);
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
            return new CubeCoordinatesImpl(x, y, z);
        }
    }
}
