using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// MvcView Object Impl
/// </summary>
public class MvcViewObjectImpl
    : MvcViewObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly GameObject mvcCanvasGameObject;
    private readonly MvcViewScript mvcViewScript;
    private MvcFrameworkObject mvcFrameworkObject;

    private Dictionary<TalonIdentificationReport, TalonCanvasObject> talonIdentificationCanvasDictionary =
        new Dictionary<TalonIdentificationReport, TalonCanvasObject>();

    #endregion Private Fields

    #region Public Constructors

    public MvcViewObjectImpl(MvcViewScript mvcViewScript, GameObject mvcCanvasGameObject)
    {
        if (mvcViewScript != null)
        {
            logger.Info("Contructing: ?", this.GetType());

            logger.Info("Setting: ?=?", typeof(MvcViewScript), mvcViewScript);
            this.mvcViewScript = mvcViewScript;
            logger.Info("Setting: ?=?", typeof(GameObject), mvcCanvasGameObject);
            this.mvcCanvasGameObject = mvcCanvasGameObject;
        }
        else
        {
            throw new ArgumentException("Unable to construct " +
                this.GetType() + ". Invalid Parameters." +
                "\n\t>mvcViewScript is null: " + (mvcViewScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override void DestroyTalonCanvas(TalonIdentificationReport talonIdentificationReport)
    {
        if (this.talonIdentificationCanvasDictionary.ContainsKey(talonIdentificationReport))
        {
            TalonCanvasObject talonCanvasObject = this.talonIdentificationCanvasDictionary[talonIdentificationReport];
            talonCanvasObject.DestroyTalonCanvas();
            this.talonIdentificationCanvasDictionary.Remove(talonIdentificationReport);
        }
        else
        {
            logger.Warn("Unable to DestroyTalonCanvas. ? is not tracked.", talonIdentificationReport);
        }
    }

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
                /*
                HashSet<TalonObject> talonObjectSet = this.mvcFrameworkObject.GetMvcModelObject().GetActiveTalonObjectSet();
                foreach (TalonObject talonObject in talonObjectSet)
                {
                    logger.Debug("?", talonObject);
                    TalonCanvasObject talonCanvasObject = this.BuildTalonCanvas(talonObject);
                    GameObject talonCanvasGameObject = GameObjectResourceLoader.Canvas.LoadTalonCanvasGameObject();
                    talonCanvasGameObject.transform.SetParent(this.mvcCanvasGameObject.transform);
                    this.talonIdentificationCanvasDictionary.Add(talonObject.GetTalonIdentificationReport(), talonCanvasObject);
                }
                */
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
                "\n\t>mvcFrameworkObject=" + mvcFrameworkObject);
        }
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkObject != null;
    }

    public override void UpdateTalonCanvas(TalonIdentificationReport talonIdentificationReport)
    {
        if (this.talonIdentificationCanvasDictionary.ContainsKey(talonIdentificationReport))
        {
            this.talonIdentificationCanvasDictionary[talonIdentificationReport].UpdateCanvas();
        }
        else
        {
            logger.Warn("Unable to UpdateTalonCanvas. ? is not tracked.", talonIdentificationReport);
        }
    }

    public override void UpdateTalonOrderList(List<TalonObject> talonObjectOrderList)
    {
        foreach (TalonObject talonObject in talonObjectOrderList)
        {
        }
        //throw new NotImplementedException();
    }

    #endregion Public Methods

    #region Private Methods

    private TalonCanvasObject BuildTalonCanvas(TalonObject talonObject)
    {
        GameObject talonCanvasPlaceHolder = new GameObject("TalonCanvasPlaceHolder");
        talonCanvasPlaceHolder.transform.SetParent(this.mvcViewScript.transform);
        talonCanvasPlaceHolder.transform.localPosition = Vector3.zero;
        TalonCanvasScript talonCanvasScript = talonCanvasPlaceHolder.AddComponent<TalonCanvasScriptImpl>();
        talonCanvasScript.Initialize(talonObject);
        return talonCanvasScript.GetTalonCanvasObject();
    }

    #endregion Private Methods
}