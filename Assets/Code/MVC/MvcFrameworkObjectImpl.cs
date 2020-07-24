using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// MvcFramework Object Impl
/// </summary>
public class MvcFrameworkObjectImpl
    : MvcFrameworkObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private MvcInitializationReport mvcInitializationReport;
    private MvcFrameworkScript mvcFrameworkScript;
    private MvcControllerObject mvcControllerObject;
    private MvcViewObject mvcViewObject;
    private MvcModelObject mvcModelObject;

    #endregion Private Fields

    #region Public Constructors

    public MvcFrameworkObjectImpl(MvcFrameworkScript mvcFrameworkScript)
    {
        if (mvcFrameworkScript != null)
        {
            logger.Info("Contructing: ?", this.GetType());
            logger.Info("Setting: ?=?", typeof(MvcFrameworkScript), mvcFrameworkScript);
            this.mvcFrameworkScript = mvcFrameworkScript;
        }
        else
        {
            throw new ArgumentException("Unable to construct ? " +
                this.GetType() + ". Invalid Parameters." +
                "\n>mvcFrameworkScript is null: " + (mvcFrameworkScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override MvcFrameworkScript GetMvcFrameworkScript()
    {
        logger.Debug("Getting ?=?", typeof(MvcModelScript), this.mvcFrameworkScript);
        return this.mvcFrameworkScript;
    }

    public override MapConstructionReport GetMapConstructionReport()
    {
        return (this.mvcInitializationReport != null)
            ? this.mvcInitializationReport.GetMapConstructionReport()
            : null;
    }

    public override MvcControllerObject GetMvcControllerObject()
    {
        return this.mvcControllerObject;
    }

    public override MvcModelObject GetMvcModelObject()
    {
        return this.mvcModelObject;
    }

    public override MvcViewObject GetMvcViewObject()
    {
        return this.mvcViewObject;
    }

    public override void Initialize(MvcInitializationReport mvcInitializationReport)
    {
        if (mvcInitializationReport != null)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting: ?=?", typeof(MvcInitializationReport), mvcInitializationReport);
                this.mvcInitializationReport = mvcInitializationReport;

                logger.Info("Setting: ?=?", typeof(MvcControllerObject), mvcFrameworkScript.GetMvcControllerScript().GetMvcControllerObject());
                this.mvcControllerObject = mvcFrameworkScript.GetMvcControllerScript().GetMvcControllerObject();
                this.mvcControllerObject.Initialize(this);

                logger.Info("Setting: ?=?", typeof(MvcModelObject), mvcFrameworkScript.GetMvcModelScript().GetMvcModelObject());
                this.mvcModelObject = mvcFrameworkScript.GetMvcModelScript().GetMvcModelObject();
                this.mvcModelObject.Initialize(this);

                logger.Info("Setting: ?=?", typeof(MvcViewObject), mvcFrameworkScript.GetMvcViewScript().GetMvcViewObject());
                this.mvcViewObject = mvcFrameworkScript.GetMvcViewScript().GetMvcViewObject();
                this.mvcViewObject.Initialize(this);
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

    public override bool IsInitialized()
    {
        return this.mvcFrameworkScript != null &&
            this.mvcControllerObject != null &&
            this.mvcModelObject != null &&
            this.mvcViewObject != null;
    }

    public override Dictionary<TeamIdEnum, ControllerTypeEnum> GetTeamIdControllerTypeDictionary()
    {
        return (this.mvcInitializationReport != null)
            ? this.mvcInitializationReport.GetTeamIdControllerTypeDictionary()
            : null;
    }

    public override Dictionary<TeamIdEnum, HashSet<MechConstructionReport>> GetTeamIdMechContructionReportDictionary()
    {
        return (this.mvcInitializationReport != null)
            ? this.mvcInitializationReport.GetTeamIdMechConstructionReportSetDictionary()
            : null;
    }

    #endregion Public Methods
}