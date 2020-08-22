/// <summary>
/// HexTile Object Api
/// </summary>
public abstract class HexTileObject
{
    #region Public Methods

    public abstract HexTileInformationReport GetHexTileInformationReport();

    public abstract HexTileScript GetHexTileScript();

    public abstract HexTileTypeEnum GetHexTileType();

    public abstract void SetOccupyingTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport);

    #endregion Public Methods
}