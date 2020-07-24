using System.Diagnostics;
using UnityEngine;

/// <summary>
/// MvcFramework Script Api
/// </summary>
public class MvcFrameworkScriptImpl
    : MvcFrameworkScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private MvcFrameworkObject mvcFrameworkObject;
    private MvcControllerScript mvcControllerScript;
    private MvcViewScript mvcViewScript;
    private MvcModelScript mvcModelScript;
    private MvcInitializationReport mvcInitializationReport;

    #endregion Private Fields

    #region Public Methods

    public override MvcFrameworkObject GetMvcFrameworkObject()
    {
        return this.mvcFrameworkObject;
    }

    public override MvcModelScript GetMvcModelScript()
    {
        return this.mvcModelScript;
    }

    public override MvcViewScript GetMvcViewScript()
    {
        return this.mvcViewScript;
    }

    public override MvcControllerScript GetMvcControllerScript()
    {
        return this.mvcControllerScript;
    }

    public override void Initialize(MvcInitializationReport mvcInitializationReport)
    {
        if (mvcInitializationReport != null)
        {
            logger.Info("Initializing Script: ?", this.GetType());
            if (!this.IsInitialized())
            {
                this.mvcFrameworkObject = new MvcFrameworkObjectImpl(this);

                this.mvcControllerScript = this.BuildMvcController();
                this.mvcModelScript = this.BuildMvcModel();
                this.mvcViewScript = this.BuildMvcView();

                this.mvcControllerScript.Initialize(this);
                this.mvcModelScript.Initialize(this);
                this.mvcViewScript.Initialize(this);
                this.mvcFrameworkObject.Initialize(mvcInitializationReport);
            }
            else
            {
                logger.Warn("Unable to Initialize Script=?. Script has already been initialized.", this.GetType());
            }
        }
        else
        {
        }
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkObject != null &&
            this.mvcControllerScript != null &&
            this.mvcModelScript != null &&
            this.mvcViewScript != null;
    }

    #endregion Public Methods

    #region Private Methods

    private MvcControllerScript BuildMvcController()
    {
        logger.Info("Building Script: ?", typeof(MvcControllerScript));
        GameObject mvcControllerGameObject = new GameObject(MvcControllerConstants.Script.GetMvcControllerGameObjectName());
        MvcControllerScript mvcControllerScript = mvcControllerGameObject.AddComponent<MvcControllerScriptImpl>();
        mvcControllerGameObject.transform.SetParent(this.transform);
        return mvcControllerScript;
    }

    private MvcModelScript BuildMvcModel()
    {
        logger.Info("Building Script: ?", typeof(MvcModelScript));
        GameObject mvcModelGameObject = new GameObject(MvcModelConstants.Script.GetMvcModelGameObjectName());
        MvcModelScript mvcModelScript = mvcModelGameObject.AddComponent<MvcModelScriptImpl>();
        mvcModelGameObject.transform.SetParent(this.transform);
        return mvcModelScript;
    }

    private MvcViewScript BuildMvcView()
    {
        logger.Info("Building Script: ?", typeof(MvcViewScript));
        GameObject mvcViewGameObject = new GameObject(MvcViewConstants.Script.GetMvcViewGameObjectName());
        MvcViewScript mvcViewScript = mvcViewGameObject.AddComponent<MvcViewScriptImpl>();
        mvcViewGameObject.transform.SetParent(this.transform);
        return mvcViewScript;
    }

    #endregion Private Methods
}