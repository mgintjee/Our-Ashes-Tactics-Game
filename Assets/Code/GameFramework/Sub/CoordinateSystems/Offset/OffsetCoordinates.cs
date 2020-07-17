/// <summary>
/// Created: 18 Oct 19
/// Updated: 16 Jan 20
/// </summary>
public class OffsetCoordinates
{
    #region Private Fields

    private readonly int colCoordinate;
    private readonly OffsetCoordinateTypeEnum offsetCoordinateType;
    private readonly int rowCoordinate;

    #endregion Private Fields

    #region Public Constructors

    public OffsetCoordinates(int colCoordinate, int rowCoordinate, OffsetCoordinateTypeEnum offsetCoordinateType)
    {
        this.colCoordinate = colCoordinate;
        this.rowCoordinate = rowCoordinate;
        this.offsetCoordinateType = offsetCoordinateType;
    }

    #endregion Public Constructors

    #region Public Methods

    public int GetCol()
    {
        return this.colCoordinate;
    }

    public OffsetCoordinateTypeEnum GetOffsetCoordinateType()
    {
        return this.offsetCoordinateType;
    }

    public int GetRow()
    {
        return this.rowCoordinate;
    }

    #endregion Public Methods
}