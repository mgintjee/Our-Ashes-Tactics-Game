using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Talon Object Impl
/// </summary>
public class TalonObjectImpl
    : TalonObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly TalonConstructionReport talonConstructionReport = null;
    private readonly TalonScript talonScript = null;
    private TalonBehavior talonBehavior = null;
    private TalonVisual talonVisual = null;

    #endregion Private Fields

    #region Public Constructors

    public TalonObjectImpl(TalonScript talonScript, TalonConstructionReport talonConstructionReport)
    {
        if (talonScript != null &&
            talonConstructionReport != null)
        {
            logger.Info("Constructing: ?.", this.GetType());
            this.talonScript = talonScript;
            this.talonConstructionReport = talonConstructionReport;
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(TalonScript) + " is null: " + (talonScript == null) +
                "\n\t>" + typeof(TalonConstructionReport) + " is null: " + (talonConstructionReport == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override void AddWeapon(WeaponObject weaponObject)
    {
        this.talonVisual.AddWeaponObject(weaponObject);
        this.talonBehavior.AddWeaponBehavior(weaponObject.GetWeaponBehavior());
    }

    public override void ApplyPaintScheme()
    {
        this.talonVisual.ApplyPaintScheme();
    }

    public override CubeCoordinates GetCubeCoordinates()
    {
        return this.talonBehavior.GetCubeCoordinates();
    }

    public override TalonAttributesReport GetTalonAttributesReport()
    {
        return this.talonBehavior.GetCurrentTalonAttributesReport();
    }

    public override TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire)
    {
        return this.talonBehavior.GetTalonCombatOrderReport(pathObjectFire);
    }

    public override TalonIdentificationReport GetTalonIdentificationReport()
    {
        return (this.talonConstructionReport != null)
            ? this.talonConstructionReport.GetTalonIdentificationReport()
            : null;
    }

    public override TalonInformationReport GetTalonInformationReport()
    {
        return new TalonInformationReport.Builder()
            .SetTalonAttributesReport(this.talonBehavior.GetCurrentTalonAttributesReport())
            .SetTalonIdentifcationReport(this.GetTalonIdentificationReport())
            .SetPossibleTalonActionOrderReportSet(this.GetPossibleTalonActionOrderReportSet())
            .Build();
    }

    public override TalonScript GetTalonScript()
    {
        return this.talonScript;
    }

    public override void Initialize()
    {
        if (!this.IsInitialized())
        {
            TalonIdentificationReport talonIdentificationReport = this.GetTalonIdentificationReport();
            if (talonIdentificationReport != null)
            {
                this.talonBehavior = new TalonBehaviorImpl(talonIdentificationReport);
                this.talonVisual = new TalonVisualImpl(this, this.talonConstructionReport);
            }
            else
            {
                throw new ArgumentException("Unable to initialize ?" + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(TalonIdentificationReport) + " is null: " + (talonIdentificationReport == null));
            }
        }
        else
        {
            logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
        }
    }

    public override TalonActionResultReport InputTalonActionOrderReport(TalonActionOrderReport talonActionOrder)
    {
        if (talonActionOrder.GetTalonActionType() == TalonActionTypeEnum.Move)
        {
            this.SetCubeCoordinates(talonActionOrder.GetPathObject().GetCubeCoordinatesEnd());
        }
        return this.talonBehavior.InputTalonActionOrderReport(talonActionOrder);
    }

    public override TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport)
    {
        TalonCombatResultReport talonCombatResultReport = this.talonBehavior.InputTalonCombatOrderReport(talonCombatOrderReport);
        return talonCombatResultReport;
    }

    public override bool IsInitialized()
    {
        return this.talonBehavior != null &&
            this.talonVisual != null;
    }

    public override void ResetTalonAttributeValues()
    {
        this.talonBehavior.ResetTalonAttributeValues();
    }

    public override void SetCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            CubeCoordinates currentCubeCoordinates = this.talonBehavior.GetCubeCoordinates();
            if (currentCubeCoordinates != null)
            {
                HexTileObject currentHexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(currentCubeCoordinates);
                currentHexTileObject.SetOccupyingTalonIdentificationReport(null);
            }

            this.talonBehavior.SetCubeCoordinates(cubeCoordinates);
            this.talonVisual.SetCubeCoordinates(cubeCoordinates);

            HexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(cubeCoordinates);
            hexTileObject.SetOccupyingTalonIdentificationReport(this.GetTalonIdentificationReport());
        }
        else
        {
            throw new ArgumentException("Unable to SetCubeCoordinates" +
                "\n\t>" + typeof(CubeCoordinates) + " is null");
        }
    }

    public override string ToString()
    {
        return (this.GetTalonIdentificationReport() != null)
            ? this.GetTalonIdentificationReport().ToString()
            : "null";
    }

    #endregion Public Methods

    #region Private Methods

    private HashSet<TalonActionOrderReport> GetPossibleTalonActionOrderReportSet()
    {
        return this.talonBehavior.GetPossibleTalonActionOrderReportSet();
    }

    #endregion Private Methods
}