using System;
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

    public override void Initialize(MvcFrameworkScript mvcFrameworkScript, MapConstructionReport mapConstructionReport)
    {
        if (mvcFrameworkScript != null &&
            mapConstructionReport != null)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting: ?", typeof(MvcFrameworkScript));
                this.mvcFrameworkScript = mvcFrameworkScript;

                this.BuildMechCollectionGameObject();

                this.mapScript = this.BuildMap();
                this.mapScript.Initialize(this, mapConstructionReport);

                this.mvcModelObject = new MvcModelObjectImpl(this);
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }
        else
        {
            throw new ArgumentException("Unable to initialize ?" +
                this.GetType() + ". Invalid Parameters." +
                "\n>mvcFrameworkScript=" + mvcFrameworkScript +
                "\n>mapConstructionReport=" + mapConstructionReport);
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
        logger.Info("Building: ?", typeof(MapScript));
        GameObject mapGameObject = new GameObject(MapConstants.Script.GetMapGameObjectName());
        MapScript mapScript = mapGameObject.AddComponent<MapScriptImpl>();
        mapGameObject.transform.SetParent(this.transform);
        return mapScript;
    }

    private void BuildMechCollectionGameObject()
    {
        GameObject mechCollectionGameObject = new GameObject(MvcModelConstants.Script.GetMechCollectionGameObjectName());
        mechCollectionGameObject.transform.SetParent(this.transform);
    }

    #endregion Private Methods
}