using System;
using System.Diagnostics;

/// <summary>
/// MvcView Object Impl
/// </summary>
public class MvcViewObjectImpl
    : MvcViewObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly MvcViewScript mvcViewScript;
    private MvcFrameworkObject mvcFrameworkObject;

    #endregion Private Fields

    #region Public Constructors

    public MvcViewObjectImpl(MvcViewScript mvcViewScript)
    {
        if (mvcViewScript != null)
        {
            logger.Info("Contructing Object: ?", this.GetType());

            logger.Info("Setting Script: ?=?", typeof(MvcViewScript), mvcViewScript);
            this.mvcViewScript = mvcViewScript;
        }
        else
        {
            throw new ArgumentException("Unable to construct ? " +
                this.GetType() + ". Invalid Parameters." +
                "\n>mvcViewScript is null: " + (mvcViewScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override MvcViewScript GetMvcViewScript()
    {
        return this.mvcViewScript;
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