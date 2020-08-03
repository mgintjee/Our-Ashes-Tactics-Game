using System;
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
                "\n>" + typeof(TalonScript) + " is null: " + (talonScript == null) +
                "\n>" + typeof(TalonConstructionReport) + " is null: " + (talonConstructionReport == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override TalonInformationReport GetCurrentTalonInformationReport()
    {
        return new TalonInformationReport.Builder()
            .SetTalonAttributesReport(this.talonBehavior.GetCurrentTalonAttributesReport())
            .SetTalonIdentifcationReport(this.GetTalonIdentificationReport())
            .Build();
    }

    public override TalonInformationReport GetMaximumTalonInformationReport()
    {
        return new TalonInformationReport.Builder()
            .SetTalonAttributesReport(this.talonBehavior.GetMaximumTalonAttributesReport())
            .SetTalonIdentifcationReport(this.GetTalonIdentificationReport())
            .Build();
    }

    public override TalonScript GetTalonScript()
    {
        return this.talonScript;
    }

    public override void SetCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        if(cubeCoordinates != null)
        {
            this.talonBehavior.SetCubeCoordinates(cubeCoordinates);
        }
        else
        {
            throw new ArgumentException("Unable to SetCubeCoordinates" +
                "\n>" + typeof(CubeCoordinates) + " is null: " + (cubeCoordinates == null));

        }
    }

    public override void Initialize()
    {
        if (!this.IsInitialized())
        {
            TalonIdentificationReport talonIdentificationReport = this.GetTalonIdentificationReport();
            if (talonIdentificationReport != null)
            {
                this.talonBehavior = new TalonBehaviorImpl(talonIdentificationReport.GetTalonId());
                this.talonVisual = new TalonVisualImpl(this, this.talonConstructionReport);
            }
            else
            {
                throw new ArgumentException("Unable to initialize ?" + this.GetType() + ". Invalid Parameters." +
                    "\n>" + typeof(TalonIdentificationReport) + " is null: " + (talonIdentificationReport == null));
            }
        }
        else
        {
            logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
        }
    }

    public override bool IsInitialized()
    {
        return this.talonBehavior != null &&
            this.talonVisual != null;
    }

    #endregion Public Methods

    #region Private Methods

    private TalonIdentificationReport GetTalonIdentificationReport()
    {
        return (this.talonConstructionReport != null)
            ? this.talonConstructionReport.GetTalonIdentificationReport()
            : null;
    }

    #endregion Private Methods
}