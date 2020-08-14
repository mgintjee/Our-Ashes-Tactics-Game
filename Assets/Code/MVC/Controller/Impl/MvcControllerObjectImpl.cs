using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// MvcController Object Impl
/// </summary>
public class MvcControllerObjectImpl
    : MvcControllerObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly MvcControllerScript mvcControllerScript;
    private TalonActionOrderReport actionReportToOutput = null;
    private bool determiningActionReport = false;
    private MvcFrameworkObject mvcFrameworkObject;
    private Dictionary<TalonPhalanxIdEnum, TalonControllerIdEnum> talonPhalanxIdControllerIdDictionary;

    #endregion Private Fields

    #region Public Constructors

    public MvcControllerObjectImpl(MvcControllerScript mvcControllerScript)
    {
        if (mvcControllerScript != null)
        {
            logger.Info("Contructing: ?", this.GetType());

            logger.Info("Setting: ?=?", typeof(MvcControllerScript), mvcControllerScript);
            this.mvcControllerScript = mvcControllerScript;
        }
        else
        {
            throw new ArgumentException("Unable to construct " +
                this.GetType() + ". Invalid Parameters." +
                "\n\t>mvcControllerScript is null: " + (mvcControllerScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override void BeginDecisionProcess(TalonInformationReport talonInformationReport)
    {
        this.determiningActionReport = true;
        TalonPhalanxIdEnum talonPhalanxId = talonInformationReport.GetTalonIdentificationReport().GetTalonPhalanxId();
        TalonControllerIdEnum talonControllerId = this.talonPhalanxIdControllerIdDictionary[talonPhalanxId];
        logger.Debug("Using ?=? to determine action!", typeof(TalonControllerIdEnum), talonControllerId);
        switch (talonControllerId)
        {
            //Todo: Have a map of TalonControllerId to ArtificalIntelligenceImpl if AI controlled, Null if human?
            case TalonControllerIdEnum.Controller1:
            case TalonControllerIdEnum.Controller2:
            case TalonControllerIdEnum.Controller3:
            case TalonControllerIdEnum.Controller4:
            case TalonControllerIdEnum.Controller5:
            case TalonControllerIdEnum.Controller6:
                this.actionReportToOutput = ArtificialIntelligence.DetermineBestAction(talonInformationReport.GetPossibleTalonActionOrderReportSet());
                this.determiningActionReport = false;
                break;

            default:
                logger.Error("Unable to DetermineActionReport. Invalid ?=?", typeof(TalonControllerIdEnum), talonControllerId);
                break;
        }
    }

    public override MvcControllerScript GetMvcControllerScript()
    {
        return this.mvcControllerScript;
    }

    public override void Initialize(MvcFrameworkObject mvcFrameworkObject, MvcInitializationReport mvcInitializationReport)
    {
        if (mvcFrameworkObject != null &&
            mvcInitializationReport != null)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting: ?", typeof(MvcFrameworkObject));
                this.mvcFrameworkObject = mvcFrameworkObject;

                this.talonPhalanxIdControllerIdDictionary = this.BuildTalonPhalanxIdControllerDictionary(mvcInitializationReport);
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }
        else
        {
            logger.Error("Unable to Initialize: ?. Invalid Parameters", this.GetType());
        }
    }

    public override bool IsDeterminingActionReport()
    {
        return this.determiningActionReport;
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkObject != null;
    }

    public override bool IsReadyToOutputActionReport()
    {
        return this.actionReportToOutput != null;
    }

    public override TalonActionOrderReport OutputActionReport()
    {
        TalonActionOrderReport actionReport = this.actionReportToOutput;
        this.actionReportToOutput = null;
        return actionReport;
    }

    #endregion Public Methods

    #region Private Methods

    private Dictionary<TalonPhalanxIdEnum, TalonControllerIdEnum> BuildTalonPhalanxIdControllerDictionary(MvcInitializationReport mvcInitializationReport)
    {
        Dictionary<TalonPhalanxIdEnum, TalonControllerIdEnum> talonPhalanxIdControllerIdDictionary = new Dictionary<TalonPhalanxIdEnum, TalonControllerIdEnum>();

        if (mvcInitializationReport != null)
        {
            Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary =
                mvcInitializationReport.GetTalonControllerIdPhalanxIdSetDictionary();
            foreach (TalonControllerIdEnum talonControllerId in talonControllerIdPhalanxIdSetDictionary.Keys)
            {
                HashSet<TalonPhalanxIdEnum> talonPhalanxIdSet = talonControllerIdPhalanxIdSetDictionary[talonControllerId];
                foreach (TalonPhalanxIdEnum talonPhalanxId in talonPhalanxIdSet)
                {
                    talonPhalanxIdControllerIdDictionary.Add(talonPhalanxId, talonControllerId);
                }
            }
        }
        else
        {
            throw new ArgumentException("Unable to build talonPhalanxIdControllerIdDictionary. Invalid Parameters." +
                "\n\t>" + typeof(MvcInitializationReport) + " is null");
        }

        return talonPhalanxIdControllerIdDictionary;
    }

    #endregion Private Methods
}