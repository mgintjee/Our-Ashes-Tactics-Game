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

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="hexTileScript">            </param>
    /// <param name="hexTileConstructionReport"></param>
    public HexTileObjectImpl(HexTileScript hexTileScript, HexTileConstructionReport hexTileConstructionReport)
    {
        if (hexTileScript != null &&
            hexTileConstructionReport != null)
        {
            logger.Info("Constructing: ?.", this.GetType());
            this.hexTileScript = hexTileScript;
            this.hexTileConstructionReport = hexTileConstructionReport;
            this.hexTileAttributes = HexTileAttributesConstants.GetAttributes(this.hexTileConstructionReport.GetHexTileType());
            this.hexTileVisual = new HexTileVisualImpl(this);
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n>" + typeof(HexTileScript) + " is null: " + (hexTileScript == null) +
                "\n>" + typeof(HexTileConstructionReport) + " is null: " + (hexTileConstructionReport == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override HexTileInformationReport GetHexTileInformationReport()
    {
        return new HexTileInformationReport.Builder()
            .SetHexTileAttributes(this.hexTileAttributes)
            .SetHexTileConstructionReport(this.hexTileConstructionReport)
            .SetTalonIdentificationReport(this.occupyingTalonIdentificationReport)
            .Build();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
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
        if (this.occupyingTalonIdentificationReport == null)
        {
            this.occupyingTalonIdentificationReport = talonIdentificationReport;
        }
        else
        {
            logger.Warn("Unable to set ?", typeof(TalonIdentificationReport));
        }
    }

    #endregion Public Methods
}