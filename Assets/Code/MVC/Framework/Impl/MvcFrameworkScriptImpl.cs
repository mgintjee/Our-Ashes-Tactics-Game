using System;
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

    private bool isGameActive = false;
    private MvcControllerScript mvcControllerScript;
    private MvcFrameworkObject mvcFrameworkObject;
    private MvcInitializationReport mvcInitializationReport;
    private MvcModelScript mvcModelScript;
    private MvcViewScript mvcViewScript;

    #endregion Private Fields

    #region Public Methods

    public void FixedUpdate()
    {
        if (this.IsReadyToStart() &&
            !this.isGameActive)
        {
            logger.Debug("Starting New Game");
            this.StartNewGame();
        }

        if (this.isGameActive)
        {
            logger.Debug("Continuing Game");
            this.ContinueGame();
        }
    }

    public override MvcControllerScript GetMvcControllerScript()
    {
        return this.mvcControllerScript;
    }

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

    public override void Initialize(MvcInitializationReport mvcInitializationReport)
    {
        if (mvcInitializationReport != null)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                RandomNumberGeneratorUtil.SetSeed(mvcInitializationReport.GetGameSeed());
                this.mvcInitializationReport = mvcInitializationReport;

                this.mvcFrameworkObject = new MvcFrameworkObjectImpl(this, this.mvcInitializationReport);

                this.mvcControllerScript = this.BuildMvcController();
                this.mvcModelScript = this.BuildMvcModel();
                this.mvcViewScript = this.BuildMvcView();

                this.mvcControllerScript.Initialize(this);
                this.mvcModelScript.Initialize(this,
                    this.mvcInitializationReport.GetMapConstructionReport(),
                    this.mvcInitializationReport.GetRosterConstructionReport());
                this.mvcViewScript.Initialize(this);
                this.mvcFrameworkObject.Initialize();
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }
        else
        {
            throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(MvcInitializationReport) + " is null: " + (mvcInitializationReport == null));
        }
    }

    public override bool IsGameActive()
    {
        return this.isGameActive;
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkObject != null &&
            this.mvcControllerScript != null &&
            this.mvcModelScript != null &&
            this.mvcViewScript != null;
    }

    public override void ResetMvcFramework()
    {
        this.mvcInitializationReport = null;
        GameObject.Destroy(this.mvcControllerScript.GetGameObject());
        GameObject.Destroy(this.mvcModelScript.GetGameObject());
        GameObject.Destroy(this.mvcViewScript.GetGameObject());
    }

    #endregion Public Methods

    #region Private Methods

    private MvcControllerScript BuildMvcController()
    {
        logger.Info("Building: ?", typeof(MvcControllerScript));
        GameObject mvcControllerGameObject = new GameObject(MvcControllerConstants.Script.GetMvcControllerGameObjectName());
        MvcControllerScript mvcControllerScript = mvcControllerGameObject.AddComponent<MvcControllerScriptImpl>();
        mvcControllerGameObject.transform.SetParent(this.transform);
        return mvcControllerScript;
    }

    private MvcModelScript BuildMvcModel()
    {
        logger.Info("Building: ?", typeof(MvcModelScript));
        GameObject mvcModelGameObject = new GameObject(MvcModelConstants.Script.GetMvcModelGameObjectName());
        MvcModelScript mvcModelScript = mvcModelGameObject.AddComponent<MvcModelScriptImpl>();
        mvcModelGameObject.transform.SetParent(this.transform);
        return mvcModelScript;
    }

    private MvcViewScript BuildMvcView()
    {
        logger.Info("Building: ?", typeof(MvcViewScript));
        GameObject mvcViewGameObject = new GameObject(MvcViewConstants.Script.GetMvcViewGameObjectName());
        MvcViewScript mvcViewScript = mvcViewGameObject.AddComponent<MvcViewScriptImpl>();
        mvcViewGameObject.transform.SetParent(this.transform);
        return mvcViewScript;
    }

    private void ContinueGame()
    {
        this.isGameActive = this.GetMvcFrameworkObject().ContinueGame();
        logger.Info("Continue Game=?", this.isGameActive);
        // Todo: Game is over. Do something
        if (!this.isGameActive)
        {
            LineRendererUtil.ErasePath();
            this.ResetMvcFramework();
        }
    }

    private bool IsReadyToStart()
    {
        return this.IsInitialized() &&
            this.mvcInitializationReport != null &&
            this.mvcFrameworkObject.IsInitialized() &&
            this.mvcControllerScript.IsInitialized() &&
            this.mvcModelScript.IsInitialized() &&
            this.mvcViewScript.IsInitialized();
    }

    private void StartNewGame()
    {
        logger.Info("Starting new game.");
        this.GetMvcFrameworkObject().StartNewGame();
        this.isGameActive = true;
    }

    #endregion Private Methods
}