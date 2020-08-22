using System;
using System.Diagnostics;

/// <summary>
/// HexTile Object Impl
/// </summary>
public class HexTileObjectImpl
    : HexTileObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly HexTileAttributes hexTileAttributes = null;
    private readonly HexTileConstructionReport hexTileConstructionReport = null;
    private readonly HexTileScript hexTileScript = null;
    private readonly HexTileVisual hexTileVisual = null;
    private TalonIdentificationReport occupyingTalonIdentificationReport = null;

    #endregion Private Fields

    #region Public Constructors

    public HexTileObjectImpl(HexTileScript hexTileScript, HexTileConstructionReport hexTileConstructionReport)
    {
        if (hexTileScript != null &&
            hexTileConstructionReport != null)
        {
            logger.Info("Constructing: ? with ?=?", this.GetType(), typeof(HexTileConstructionReport), hexTileConstructionReport);
            this.hexTileScript = hexTileScript;
            this.hexTileConstructionReport = hexTileConstructionReport;
            this.hexTileAttributes = HexTileAttributesConstants.GetAttributes(this.hexTileConstructionReport.GetHexTileType());
            this.hexTileVisual = new HexTileVisualImpl(this);
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(HexTileScript) + " is null: " + (hexTileScript == null) +
                "\n\t>" + typeof(HexTileConstructionReport) + " is null: " + (hexTileConstructionReport == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override HexTileInformationReport GetHexTileInformationReport()
    {
        return new HexTileInformationReport.Builder()
            .SetHexTileAttributes(this.hexTileAttributes)
            .SetHexTileConstructionReport(this.hexTileConstructionReport)
            .SetTalonIdentificationReport(this.occupyingTalonIdentificationReport)
            .Build();
    }

    public override HexTileScript GetHexTileScript()
    {
        return this.hexTileScript;
    }

    public override HexTileTypeEnum GetHexTileType()
    {
        return this.hexTileConstructionReport.GetHexTileType();
    }

    public override void SetOccupyingTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport)
    {
        this.occupyingTalonIdentificationReport = talonIdentificationReport;
    }

    #endregion Public Methods
}