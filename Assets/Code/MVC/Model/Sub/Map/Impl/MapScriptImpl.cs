using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Map Script Impl
/// </summary>
public class MapScriptImpl
    : MapScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private MapConstructionReport mapConstructionReport;

    private MapObject mapObject;

    #endregion Private Fields

    #region Public Methods

    public override MapObject GetMapObject()
    {
        return this.mapObject;
    }

    public override void Initialize(MvcModelScript mcvModelScript, MapConstructionReport mapInformationReport)
    {
        logger.Info("Initializing: ?.", this.GetType());
        if (!this.IsInitialized())
        {
            if (mcvModelScript != null &&
            mapInformationReport != null)
            {
                this.mapConstructionReport = mapInformationReport;

                this.BuildLayerLevelGameObjects();

                this.mapObject = new MapObjectImpl(this, mapInformationReport);
            }
            else
            {
                throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(MvcModelScript) + "=" + mcvModelScript +
                    "\n\t>" + typeof(MapConstructionReport) + "=" + mapInformationReport);
            }
        }
        else
        {
            logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
        }
    }

    public override bool IsInitialized()
    {
        return this.mapConstructionReport != null &&
            this.mapObject != null;
    }

    #endregion Public Methods

    #region Private Methods

    private void BuildLayerLevelGameObjects()
    {
        for (int i = 0; i < this.mapConstructionReport.GetMapRadius() + 1; ++i)
        {
            GameObject layerLevelGameObject = new GameObject(MapConstants.Script.GetMapLayerLevelGameObjectPrefix() + i);
            layerLevelGameObject.transform.SetParent(this.transform);
        }
    }

    #endregion Private Methods
}