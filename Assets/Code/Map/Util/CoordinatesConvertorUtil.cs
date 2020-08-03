public static class CoordinatesConvertorUtil
{
    #region Public Methods

    public static OffsetCoordinates CubeToOffset(CubeCoordinates cubeCoordinates, OffsetCoordinateTypeEnum offsetCoordinateType)
    {
        OffsetCoordinates offsetCoordinates = null;
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

    public static CubeCoordinates OffsetToCube(OffsetCoordinates offsetCoordinates)
    {
        CubeCoordinates cubeCoordinates = null;
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

    #endregion Public Methods

    #region Private Methods

    private static OffsetCoordinates CubeToEvenq(CubeCoordinates cubeCoordinates)
    {
        int col = cubeCoordinates.GetX();
        int row = cubeCoordinates.GetZ() + (cubeCoordinates.GetX() + (cubeCoordinates.GetX() & 1)) / 2;
        return new OffsetCoordinates(col, row, OffsetCoordinateTypeEnum.EVEN_Q);
    }

    private static OffsetCoordinates CubeToEvenr(CubeCoordinates cubeCoordinates)
    {
        int col = cubeCoordinates.GetX() + (cubeCoordinates.GetZ() + (cubeCoordinates.GetZ() & 1)) / 2;
        int row = cubeCoordinates.GetZ();
        return new OffsetCoordinates(col, row, OffsetCoordinateTypeEnum.EVEN_R);
    }

    private static OffsetCoordinates CubeToOddq(CubeCoordinates cubeCoordinates)
    {
        int col = cubeCoordinates.GetX();
        int row = cubeCoordinates.GetZ() + (cubeCoordinates.GetX() - (cubeCoordinates.GetX() & 1)) / 2;
        return new OffsetCoordinates(col, row, OffsetCoordinateTypeEnum.ODD_Q);
    }

    private static OffsetCoordinates CubeToOddr(CubeCoordinates cubeCoordinates)
    {
        int col = cubeCoordinates.GetX() + (cubeCoordinates.GetZ() - (cubeCoordinates.GetZ() & 1)) / 2;
        int row = cubeCoordinates.GetZ();
        return new OffsetCoordinates(col, row, OffsetCoordinateTypeEnum.ODD_R);
    }

    private static CubeCoordinates EvenqToCube(int col, int row)
    {
        int x = row;
        int z = col - (row + (row & 1)) / 2;
        int y = -x - z;
        return new CubeCoordinates(x, y, z);
    }

    private static CubeCoordinates EvenrToCube(int col, int row)
    {
        int x = col - (row + (row & 1)) / 2;
        int z = row;
        int y = -x - z;
        return new CubeCoordinates(x, y, z);
    }

    private static CubeCoordinates OddqToCube(int col, int row)
    {
        int x = row;
        int z = col - (row - (row & 1)) / 2;
        int y = -x - z;
        return new CubeCoordinates(x, y, z);
    }

    private static CubeCoordinates OddrToCube(int col, int row)
    {
        int x = col - (row - (row & 1)) / 2;
        int z = row;
        int y = -x - z;
        return new CubeCoordinates(x, y, z);
    }

    #endregion Private Methods
}