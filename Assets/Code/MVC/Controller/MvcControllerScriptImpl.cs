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
            logger.Info("Initializing Script: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting Script: ?", typeof(MvcFrameworkScript));
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
            logger.Error("Unable to Initialize: ?. Invalid Parameters", this.GetType());
        }
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkScript != null &&
            this.mvcControllerObject != null;
    }

    #endregion Public Methods
}