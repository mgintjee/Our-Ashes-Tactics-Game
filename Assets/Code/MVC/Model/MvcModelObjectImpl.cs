using System;
using System.Diagnostics;

/// <summary>
/// MvcModel Object Impl
/// </summary>
public class MvcModelObjectImpl
    : MvcModelObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly MvcModelScript mvcModelScript;
    private MvcFrameworkObject mvcFrameworkObject;
    private MapObject MapObject;

    #endregion Private Fields

    #region Public Constructors

    public MvcModelObjectImpl(MvcModelScript mvcModelScript)
    {
        if (mvcModelScript != null)
        {
            logger.Info("Contructing Object: ?", this.GetType());

            logger.Info("Setting Script: ?=?", typeof(MvcModelScript), mvcModelScript);
            this.mvcModelScript = mvcModelScript;
        }
        else
        {
            throw new ArgumentException("Unable to construct ? " +
                this.GetType() + ". Invalid Parameters." +
                "\n>mvcModelScript is null: " + (mvcModelScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override MvcModelScript GetMvcModelScript()
    {
        return this.mvcModelScript;
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