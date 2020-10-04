/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Coordinates.Cube;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Coordinates.Offset;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates
{
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

        private static IOffsetCoordinates CubeToEvenq(ICubeCoordinates cubeCoordinates)
        {
            int col = cubeCoordinates.GetX();
            int row = cubeCoordinates.GetZ() + (cubeCoordinates.GetX() + (cubeCoordinates.GetX() & 1)) / 2;
            return new OffsetCoordinatesImpl(col, row, OffsetCoordinateTypeEnum.EVEN_Q);
        }

        private static IOffsetCoordinates CubeToEvenr(ICubeCoordinates cubeCoordinates)
        {
            int col = cubeCoordinates.GetX() + (cubeCoordinates.GetZ() + (cubeCoordinates.GetZ() & 1)) / 2;
            int row = cubeCoordinates.GetZ();
            return new OffsetCoordinatesImpl(col, row, OffsetCoordinateTypeEnum.EVEN_R);
        }

        private static IOffsetCoordinates CubeToOddq(ICubeCoordinates cubeCoordinates)
        {
            int col = cubeCoordinates.GetX();
            int row = cubeCoordinates.GetZ() + (cubeCoordinates.GetX() - (cubeCoordinates.GetX() & 1)) / 2;
            return new OffsetCoordinatesImpl(col, row, OffsetCoordinateTypeEnum.ODD_Q);
        }

        private static IOffsetCoordinates CubeToOddr(ICubeCoordinates cubeCoordinates)
        {
            int col = cubeCoordinates.GetX() + (cubeCoordinates.GetZ() - (cubeCoordinates.GetZ() & 1)) / 2;
            int row = cubeCoordinates.GetZ();
            return new OffsetCoordinatesImpl(col, row, OffsetCoordinateTypeEnum.ODD_R);
        }

        private static ICubeCoordinates EvenqToCube(int col, int row)
        {
            int x = row;
            int z = col - (row + (row & 1)) / 2;
            int y = -x - z;
            return new CubeCoordinatesImpl(x, y, z);
        }

        private static ICubeCoordinates EvenrToCube(int col, int row)
        {
            int x = col - (row + (row & 1)) / 2;
            int z = row;
            int y = -x - z;
            return new CubeCoordinatesImpl(x, y, z);
        }

        private static ICubeCoordinates OddqToCube(int col, int row)
        {
            int x = row;
            int z = col - (row - (row & 1)) / 2;
            int y = -x - z;
            return new CubeCoordinatesImpl(x, y, z);
        }

        private static ICubeCoordinates OddrToCube(int col, int row)
        {
            int x = col - (row - (row & 1)) / 2;
            int z = row;
            int y = -x - z;
            return new CubeCoordinatesImpl(x, y, z);
        }
    }
}