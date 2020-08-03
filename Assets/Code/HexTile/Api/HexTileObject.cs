/// <summary>
/// HexTile Object Api
/// </summary>
public abstract class HexTileObject
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract HexTileInformationReport GetHexTileInformationReport();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract HexTileScript GetHexTileScript();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract HexTileTypeEnum GetHexTileType();

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonIdentificationReport"></param>
    public abstract void SetOccupyingTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport);

    #endregion Public Methods
}