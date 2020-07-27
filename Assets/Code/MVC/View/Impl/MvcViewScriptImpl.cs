using System;
using System.Diagnostics;

/// <summary>
/// MvcView Script Impl
/// </summary>
public class MvcViewScriptImpl
    : MvcViewScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private MvcViewObject mvcViewObject;

    private MvcFrameworkScript mvcFrameworkScript;

    #endregion Private Fields

    #region Public Methods

    public override void Initialize(MvcFrameworkScript mvcFrameworkScript)
    {
        if (mvcFrameworkScript != null)
        {
            logger.Info("Initializing Script: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting Script: ?", typeof(MvcFrameworkScript));
                this.mvcFrameworkScript = mvcFrameworkScript;

                this.mvcViewObject = new MvcViewObjectImpl(this);
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }
        else
        {
            throw new ArgumentException("Unable to initialize " +
                this.GetType() + ". Invalid Parameters." +
                "\n>mvcFrameworkScript=" + mvcFrameworkScript);
        }
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkScript != null &&
            this.mvcViewObject != null;
    }

    public override MvcViewObject GetMvcViewObject()
    {
        return this.mvcViewObject;
    }

    #endregion Public Methods
}