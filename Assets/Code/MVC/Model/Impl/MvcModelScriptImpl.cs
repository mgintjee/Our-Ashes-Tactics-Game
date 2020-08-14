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

    private MapScript mapScript;
    private MvcFrameworkScript mvcFrameworkScript;
    private MvcModelObject mvcModelObject;

    #endregion Private Fields

    #region Public Methods

    public override MvcModelObject GetMvcModelObject()
    {
        return this.mvcModelObject;
    }

    public override void Initialize(MvcFrameworkScript mvcFrameworkScript, MapInformationReport mapInformationReport)
    {
        logger.Info("Initializing: ?", this.GetType());
        if (!this.IsInitialized())
        {
            if (mvcFrameworkScript != null &&
            mapInformationReport != null)
            {
                logger.Info("Setting: ?", typeof(MvcFrameworkScript));
                this.mvcFrameworkScript = mvcFrameworkScript;

                this.BuildMechCollectionGameObject();

                this.mapScript = this.BuildMap();
                this.mapScript.Initialize(this, mapInformationReport);

                this.mvcModelObject = new MvcModelObjectImpl(this);
            }
            else
            {
                throw new ArgumentException("Unable to initialize ?" + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(MvcFrameworkScript) + " is null: " + (mvcFrameworkScript == null) +
                    "\n\t>" + typeof(MapInformationReport) + " is null: " + (mapInformationReport == null));
            }
        }
        else
        {
            logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
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
        GameObject mechCollectionGameObject = new GameObject(MvcModelConstants.Script.GetTalonCollectionGameObjectName());
        mechCollectionGameObject.transform.SetParent(this.transform);
    }

    #endregion Private Methods
}