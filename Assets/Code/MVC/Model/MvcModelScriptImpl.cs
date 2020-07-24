using System.Diagnostics;
using UnityEngine;

/// <summary>
/// MvcModel Script Impl
/// </summary>
public class MvcModelScriptImpl
    : MvcModelScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private MvcModelObject mvcModelObject;

    private MvcFrameworkScript mvcFrameworkScript;
    private MapScript mapScript;

    #endregion Private Fields

    #region Public Methods

    public override MvcModelObject GetMvcModelObject()
    {
        return this.mvcModelObject;
    }

    public override void Initialize(MvcFrameworkScript mvcFrameworkScript)
    {
        if (mvcFrameworkScript != null &&
            mvcFrameworkScript.GetMvcFrameworkObject() != null)
        {
            logger.Info("Initializing Script: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting Script: ?", typeof(MvcFrameworkScript));
                this.mvcFrameworkScript = mvcFrameworkScript;

                this.mvcModelObject = new MvcModelObjectImpl(this);

                this.mapScript = this.BuildMap();
                this.mapScript.Initialize(this, mvcFrameworkScript.GetMvcFrameworkObject().GetMapConstructionReport());
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
            this.mvcModelObject != null;
    }

    #endregion Public Methods

    #region Private Methods

    private MapScript BuildMap()
    {
        logger.Info("Building Script: ?", typeof(MapScript));
        GameObject mapGameObject = new GameObject(MvcModelConstants.Script.GetMapGameObjectName());
        MapScript mapScript = mapGameObject.AddComponent<MapScriptImpl>();
        mapGameObject.transform.SetParent(this.transform);
        return mapScript;
    }

    #endregion Private Methods
}