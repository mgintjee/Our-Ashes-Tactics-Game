using System;
using System.Diagnostics;

/// <summary>
/// MvcController Script Impl
/// </summary>
public class MvcControllerScriptImpl
    : MvcControllerScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private MvcControllerObject mvcControllerObject;

    private MvcFrameworkScript mvcFrameworkScript;

    #endregion Private Fields

    #region Public Methods

    public override MvcControllerObject GetMvcControllerObject()
    {
        return this.mvcControllerObject;
    }

    public override void Initialize(MvcFrameworkScript mvcFrameworkScript)
    {
        if (mvcFrameworkScript != null)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting: ?", typeof(MvcFrameworkScript));
                this.mvcFrameworkScript = mvcFrameworkScript;

                this.mvcControllerObject = new MvcControllerObjectImpl(this);
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }
        else
        {
            throw new ArgumentException("Unable to initialize ?" + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(MvcFrameworkScript) + " is null: " + (mvcFrameworkScript == null));
        }
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkScript != null &&
            this.mvcControllerObject != null;
    }

    #endregion Public Methods
}