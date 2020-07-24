using System;
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
    private MvcFrameworkObject mvcFrameworkObject;

    #endregion Private Fields

    #region Public Constructors

    public MvcControllerObjectImpl(MvcControllerScript mvcControllerScript)
    {
        if (mvcControllerScript != null)
        {
            logger.Info("Contructing Object: ?", this.GetType());

            logger.Info("Setting Script: ?=?", typeof(MvcControllerScript), mvcControllerScript);
            this.mvcControllerScript = mvcControllerScript;
        }
        else
        {
            throw new ArgumentException("Unable to construct ? " +
                this.GetType() + ". Invalid Parameters." +
                "\n>mvcControllerScript is null: " + (mvcControllerScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override MvcControllerScript GetMvcControllerScript()
    {
        return this.mvcControllerScript;
    }

    public override void Initialize(MvcFrameworkObject mvcFrameworkObject)
    {
        if (mvcFrameworkObject != null)
        {
            logger.Info("Initializing Object: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting Object: ?", typeof(MvcFrameworkObject));
                this.mvcFrameworkObject = mvcFrameworkObject;
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
        return false;
    }

    #endregion Public Methods
}